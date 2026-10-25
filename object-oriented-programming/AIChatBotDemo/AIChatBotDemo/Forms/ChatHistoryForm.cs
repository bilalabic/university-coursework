using System;
using System.Linq;
using System.Windows.Forms;
using AIChatBotDemo.Services;

namespace AIChatBotDemo.Forms
{
    public partial class ChatHistoryForm : Form
    {
        private readonly ChatService _chatService;
        public string? SelectedSessionId { get; private set; }

        public ChatHistoryForm(ChatService chatService)
        {
            InitializeComponent();
            _chatService = chatService;
            LoadHistory();
        }

        private void LoadHistory(string? filter = null)
        {
            dgvHistory.Rows.Clear();
            var sessions = _chatService.Sessions;

            if (!string.IsNullOrEmpty(filter))
            {
                sessions = sessions.Where(s => 
                    s.Title.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                    s.Messages.Any(m => m.Content.Contains(filter, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            foreach (var session in sessions)
            {
                dgvHistory.Rows.Add(
                    session.Title,
                    session.Model,
                    session.UpdatedAt.ToString("dd.MM.yyyy HH:mm"),
                    session.MessageCount
                );
                dgvHistory.Rows[dgvHistory.Rows.Count - 1].Tag = session.Id;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadHistory(txtSearch.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sohbet seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedSessionId = dgvHistory.SelectedRows[0].Tag?.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir sohbet seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili sohbeti silmek istediğinize emin misiniz?", "Onay", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sessionId = dgvHistory.SelectedRows[0].Tag?.ToString();
                if (!string.IsNullOrEmpty(sessionId))
                {
                    _chatService.DeleteSession(sessionId);
                    LoadHistory(txtSearch.Text);
                }
            }
        }

        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnOpen_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
