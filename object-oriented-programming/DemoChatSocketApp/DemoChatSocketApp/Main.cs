using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoChatSocketApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            mtxtIP.Text = "127.0.0.1";
            mtxtPort.Text = "8080";
        }

        private void btnServerCreate_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                string username = mtxtUsername.Text.Trim();
                string ip = mtxtIP.Text.Trim();
                int port = int.Parse(mtxtPort.Text.Trim());

                ChatServer serverForm = new ChatServer(username, ip, port);
                serverForm.Show();
                this.Hide();
            }
        }

        private void btnClientCon_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                string username = mtxtUsername.Text.Trim();
                string ip = mtxtIP.Text.Trim();
                int port = int.Parse(mtxtPort.Text.Trim());

                ChatClient clientForm = new ChatClient(username, ip, port);
                clientForm.Show();
                this.Hide();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(mtxtUsername.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mtxtIP.Text))
            {
                MessageBox.Show("Lütfen IP adresi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtIP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mtxtPort.Text))
            {
                MessageBox.Show("Lütfen port numarası giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtPort.Focus();
                return false;
            }

            if (!int.TryParse(mtxtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Lütfen geçerli bir port numarası giriniz (1-65535)!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtPort.Focus();
                return false;
            }

            return true;
        }
    }
}

