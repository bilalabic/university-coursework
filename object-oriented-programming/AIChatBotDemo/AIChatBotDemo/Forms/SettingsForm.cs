using System;
using System.Windows.Forms;
using AIChatBotDemo.Models;
using AIChatBotDemo.Services;

namespace AIChatBotDemo.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settingsService;

        public SettingsForm(SettingsService settingsService)
        {
            InitializeComponent();
            _settingsService = settingsService;
            LoadSettings();
        }

        private void LoadSettings()
        {
            var settings = _settingsService.Settings;

            // API
            txtOpenAIKey.Text = _settingsService.GetOpenAIKey();
            chkOpenAIEnabled.Checked = settings.OpenAI.IsEnabled;
            txtGeminiKey.Text = _settingsService.GetGeminiKey();
            chkGeminiEnabled.Checked = settings.Gemini.IsEnabled;

            // Model
            foreach (var model in SupportedModels.GetAllModels())
                cmbDefaultModel.Items.Add(model.Id);
            cmbDefaultModel.SelectedItem = settings.DefaultModel;

            trkTemperature.Value = (int)(settings.Temperature * 100);
            lblTempValue.Text = settings.Temperature.ToString("0.00");
            numMaxTokens.Value = settings.MaxTokens;
            chkStreaming.Checked = settings.UseStreaming;
            chkAutoSave.Checked = settings.AutoSave;
        }

        private void trkTemperature_Scroll(object sender, EventArgs e)
        {
            lblTempValue.Text = (trkTemperature.Value / 100.0).ToString("0.00");
        }

        private async void btnTestOpenAI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpenAIKey.Text))
            {
                MessageBox.Show("API key giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTestOpenAI.Enabled = false;
            btnTestOpenAI.Text = "...";

            var service = new OpenAIService(txtOpenAIKey.Text);
            var (success, message) = await service.TestConnectionAsync();

            MessageBox.Show(message, success ? "Başarılı ✓" : "Hata", 
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            btnTestOpenAI.Enabled = true;
            btnTestOpenAI.Text = "🔗 Test";
        }

        private async void btnTestGemini_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGeminiKey.Text))
            {
                MessageBox.Show("API key giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnTestGemini.Enabled = false;
            btnTestGemini.Text = "...";

            var service = new GeminiService(txtGeminiKey.Text);
            var (success, message) = await service.TestConnectionAsync();

            MessageBox.Show(message, success ? "Başarılı ✓" : "Hata", 
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            btnTestGemini.Enabled = true;
            btnTestGemini.Text = "🔗 Test";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var settings = _settingsService.Settings;

            _settingsService.SetOpenAIKey(txtOpenAIKey.Text);
            settings.OpenAI.IsEnabled = chkOpenAIEnabled.Checked && !string.IsNullOrEmpty(txtOpenAIKey.Text);

            _settingsService.SetGeminiKey(txtGeminiKey.Text);
            settings.Gemini.IsEnabled = chkGeminiEnabled.Checked && !string.IsNullOrEmpty(txtGeminiKey.Text);

            settings.DefaultModel = cmbDefaultModel.SelectedItem?.ToString() ?? "gpt-4o";
            settings.Temperature = trkTemperature.Value / 100.0;
            settings.MaxTokens = (int)numMaxTokens.Value;
            settings.UseStreaming = chkStreaming.Checked;
            settings.AutoSave = chkAutoSave.Checked;

            _settingsService.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
