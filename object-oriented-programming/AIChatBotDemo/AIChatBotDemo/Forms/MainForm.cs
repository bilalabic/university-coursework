using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIChatBotDemo.Models;
using AIChatBotDemo.Services;
using AIChatBotDemo.Helpers;
using Newtonsoft.Json;

namespace AIChatBotDemo.Forms
{
    public partial class MainForm : Form
    {
        private readonly SettingsService _settingsService;
        private readonly ChatService _chatService;
        private readonly ImageService _imageService;
        private OpenAIService? _openAIService;
        private GeminiService? _geminiService;

        private CancellationTokenSource? _cts;
        private bool _isProcessing;
        private string? _pendingImageBase64;

        public MainForm()
        {
            InitializeComponent();
            _settingsService = new SettingsService();
            _chatService = new ChatService();
            _imageService = new ImageService();
            _chatService.SessionChanged += (s, e) => _ = DisplayCurrentChat();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            ApplyTheme(_settingsService.Settings.Theme == "dark");
            LoadModels();
            InitializeServices();
            RefreshChatList();

            try
            {
                await webViewChat.EnsureCoreWebView2Async();
                await DisplayCurrentChat();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 başlatılamadı: {ex.Message}\n\nWebView2 Runtime yüklü olduğundan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateStatus("Hazır");
        }

        private void InitializeServices()
        {
            var openAIKey = _settingsService.GetOpenAIKey();
            var geminiKey = _settingsService.GetGeminiKey();

            if (!string.IsNullOrEmpty(openAIKey))
                _openAIService = new OpenAIService(openAIKey);
            if (!string.IsNullOrEmpty(geminiKey))
                _geminiService = new GeminiService(geminiKey);
        }

        private void LoadModels()
        {
            cmbModel.Items.Clear();
            var settings = _settingsService.Settings;

            foreach (var model in SupportedModels.GetAllModels())
            {
                if ((model.Provider == "OpenAI" && settings.OpenAI.IsEnabled) ||
                    (model.Provider == "Google" && settings.Gemini.IsEnabled))
                {
                    cmbModel.Items.Add(model.Id);
                }
            }

            if (cmbModel.Items.Count > 0)
                cmbModel.SelectedIndex = 0;
        }

        private async Task DisplayCurrentChat()
        {
            if (_chatService.CurrentSession == null || webViewChat.CoreWebView2 == null) return;
            var isDark = _settingsService.Settings.Theme == "dark";
            var html = MarkdownHelper.MessagesToHtml(_chatService.CurrentSession.Messages, isDark);
            webViewChat.NavigateToString(html);
            await Task.Delay(100);
            await ScrollToBottom();
            Text = $"AI ChatBot Pro - {_chatService.CurrentSession.Title}";
        }

        private async Task ScrollToBottom()
        {
            try { await webViewChat.CoreWebView2.ExecuteScriptAsync("window.scrollTo(0, document.body.scrollHeight);"); }
            catch { }
        }

        private async void btnSend_Click(object sender, EventArgs e) => await SendMessage();

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            var text = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(text) || _isProcessing) return;

            var model = cmbModel.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Lütfen bir model seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var isOpenAI = model.StartsWith("gpt");
            if ((isOpenAI && _openAIService == null) || (!isOpenAI && _geminiService == null))
            {
                MessageBox.Show("Lütfen önce API ayarlarını yapılandırın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isProcessing = true;
            SetUIEnabled(false);

            try
            {
                // Kullanıcı mesajı
                var userMsg = new ChatMessage { Role = "user", Content = text };
                if (!string.IsNullOrEmpty(_pendingImageBase64))
                {
                    userMsg.Images.Add(_pendingImageBase64);
                    ClearImagePreview();
                }

                _chatService.AddMessage(userMsg);
                txtMessage.Clear();
                await DisplayCurrentChat();

                // AI yanıtı
                var assistantMsg = new ChatMessage { Role = "assistant", Content = "", Model = model };
                _chatService.AddMessage(assistantMsg);

                _cts = new CancellationTokenSource();
                var settings = _settingsService.Settings;
                var fullContent = "";

                if (settings.UseStreaming)
                {
                    var messages = _chatService.CurrentSession.Messages.SkipLast(1).ToList();
                    
                    if (isOpenAI)
                    {
                        await foreach (var chunk in _openAIService!.StreamMessageAsync(messages, model, settings.Temperature, settings.MaxTokens, _cts.Token))
                        {
                            if (chunk.IsComplete) break;
                            fullContent += chunk.Content;
                            assistantMsg.Content = fullContent;
                            await DisplayCurrentChat();
                        }
                    }
                    else
                    {
                        await foreach (var chunk in _geminiService!.StreamMessageAsync(messages, model, settings.Temperature, settings.MaxTokens, _cts.Token))
                        {
                            if (chunk.IsComplete) break;
                            fullContent += chunk.Content;
                            assistantMsg.Content = fullContent;
                            await DisplayCurrentChat();
                        }
                    }
                }
                else
                {
                    var messages = _chatService.CurrentSession.Messages.SkipLast(1).ToList();
                    LLMResponse response;

                    if (isOpenAI)
                        response = await _openAIService!.SendMessageAsync(messages, model, settings.Temperature, settings.MaxTokens, _cts.Token);
                    else
                        response = await _geminiService!.SendMessageAsync(messages, model, settings.Temperature, settings.MaxTokens, _cts.Token);

                    if (!response.Success)
                        throw new Exception(response.Error);

                    fullContent = response.Content;
                }

                assistantMsg.Content = fullContent;
                assistantMsg.Timestamp = DateTime.Now;
                await DisplayCurrentChat();

                if (settings.AutoSave)
                    _chatService.SaveCurrentSession();

                UpdateStatus($"Yanıt alındı - {model}");
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("İptal edildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Hata oluştu");
            }
            finally
            {
                _isProcessing = false;
                SetUIEnabled(true);
            }
        }

        private void SetUIEnabled(bool enabled)
        {
            txtMessage.Enabled = enabled;
            btnSend.Enabled = enabled;
            btnSend.Visible = enabled;
            btnCancel.Visible = !enabled;
            btnAttachImage.Enabled = enabled;
            cmbModel.Enabled = enabled;
            progressBar.Visible = !enabled;
        }

        private void btnCancel_Click(object sender, EventArgs e) => _cts?.Cancel();

        // Görsel işlemleri
        private void btnAttachImage_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Görseller|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.webp",
                Title = "Görsel Seç"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                LoadImage(dialog.FileName);
        }

        private void LoadImage(string path)
        {
            try
            {
                var image = Image.FromFile(path);
                _pendingImageBase64 = _imageService.ImageToBase64(image);
                picPreview.Image = image;
                picPreview.Visible = true;
                btnRemoveImage.Visible = true;
                UpdateStatus("Görsel eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görsel yüklenemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e) => ClearImagePreview();

        private void ClearImagePreview()
        {
            _pendingImageBase64 = null;
            picPreview.Image = null;
            picPreview.Visible = false;
            btnRemoveImage.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V) && Clipboard.ContainsImage())
            {
                var image = Clipboard.GetImage();
                if (image != null)
                {
                    _pendingImageBase64 = _imageService.ImageToBase64(image);
                    picPreview.Image = image;
                    picPreview.Visible = true;
                    btnRemoveImage.Visible = true;
                    UpdateStatus("Görsel yapıştırıldı");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                if (_imageService.IsSupportedFormat(files[0]))
                    LoadImage(files[0]);
            }
        }

        // Sohbet listesi
        private void RefreshChatList()
        {
            listChats.Items.Clear();
            foreach (var session in _chatService.Sessions)
                listChats.Items.Add(session.Title);
            
            if (_chatService.Sessions.Count > 0)
                listChats.SelectedIndex = 0;
        }

        private void listChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listChats.SelectedIndex >= 0 && listChats.SelectedIndex < _chatService.Sessions.Count)
            {
                var session = _chatService.Sessions[listChats.SelectedIndex];
                _chatService.SwitchSession(session.Id);
            }
        }

        private void btnNewChat_Click(object sender, EventArgs e)
        {
            _chatService.NewSession();
            RefreshChatList();
        }

        // Menü işlemleri
        private void menuNewChat_Click(object sender, EventArgs e) => btnNewChat_Click(sender, e);

        private void menuSaveChat_Click(object sender, EventArgs e)
        {
            _chatService.SaveCurrentSession();
            UpdateStatus("Sohbet kaydedildi");
        }

        private async void menuExportJson_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "JSON|*.json", FileName = $"{_chatService.CurrentSession.Title}.json" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var json = JsonConvert.SerializeObject(_chatService.CurrentSession, Formatting.Indented);
                await File.WriteAllTextAsync(dialog.FileName, json);
                UpdateStatus("JSON olarak kaydedildi");
            }
        }

        private async void menuExportTxt_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "TXT|*.txt", FileName = $"{_chatService.CurrentSession.Title}.txt" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var lines = _chatService.CurrentSession.Messages.Select(m => $"[{(m.IsUser ? "Kullanıcı" : "Asistan")}] {m.Timestamp:HH:mm}\n{m.Content}\n");
                await File.WriteAllTextAsync(dialog.FileName, string.Join("\n", lines));
                UpdateStatus("TXT olarak kaydedildi");
            }
        }

        private void menuExit_Click(object sender, EventArgs e) => Close();

        private void menuApiSettings_Click(object sender, EventArgs e)
        {
            using var form = new SettingsForm(_settingsService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                InitializeServices();
                LoadModels();
            }
        }

        private void menuLightTheme_Click(object sender, EventArgs e)
        {
            _settingsService.Settings.Theme = "light";
            _settingsService.Save();
            ApplyTheme(false);
            _ = DisplayCurrentChat();
        }

        private void menuDarkTheme_Click(object sender, EventArgs e)
        {
            _settingsService.Settings.Theme = "dark";
            _settingsService.Save();
            ApplyTheme(true);
            _ = DisplayCurrentChat();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            using var form = new AboutForm();
            form.ShowDialog();
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus($"Model: {cmbModel.SelectedItem}");
        }

        // Yardımcı metodlar
        private void ApplyTheme(bool isDark)
        {
            // Ana form
            BackColor = isDark ? ThemeHelper.Dark.Background : ThemeHelper.Light.Background;
            
            // Sidebar
            panelSidebar.BackColor = isDark ? ThemeHelper.Dark.Sidebar : ThemeHelper.Light.Sidebar;
            lblAppTitle.ForeColor = isDark ? ThemeHelper.Dark.Text : Color.White;
            lblChats.ForeColor = isDark ? ThemeHelper.Dark.TextSecondary : ThemeHelper.Light.TextSecondary;
            listChats.BackColor = isDark ? ThemeHelper.Dark.Sidebar : ThemeHelper.Light.Sidebar;
            listChats.ForeColor = isDark ? ThemeHelper.Dark.Text : Color.FromArgb(229, 231, 235);
            
            // Chat area
            panelChat.BackColor = isDark ? ThemeHelper.Dark.Background : ThemeHelper.Light.Background;
            panelInput.BackColor = isDark ? ThemeHelper.Dark.Background : ThemeHelper.Light.Background;
            panelInputInner.BackColor = isDark ? ThemeHelper.Dark.Surface : ThemeHelper.Light.Surface;
            
            // Input
            txtMessage.BackColor = isDark ? ThemeHelper.Dark.InputBg : Color.FromArgb(249, 250, 251);
            txtMessage.ForeColor = isDark ? ThemeHelper.Dark.Text : ThemeHelper.Light.Text;
            
            // Buttons
            btnNewChat.BackColor = ThemeHelper.Light.Primary;
            btnSend.BackColor = ThemeHelper.Light.Primary;
            btnSend.FlatAppearance.MouseOverBackColor = ThemeHelper.Light.PrimaryHover;
            
            // ComboBox
            cmbModel.BackColor = isDark ? ThemeHelper.Dark.InputBg : Color.FromArgb(249, 250, 251);
            cmbModel.ForeColor = isDark ? ThemeHelper.Dark.TextSecondary : ThemeHelper.Light.TextSecondary;
            
            // Menu & Status
            menuStrip.BackColor = isDark ? ThemeHelper.Dark.Surface : ThemeHelper.Light.Background;
            menuStrip.ForeColor = isDark ? ThemeHelper.Dark.Text : ThemeHelper.Light.Text;
            statusStrip.BackColor = isDark ? ThemeHelper.Dark.Surface : ThemeHelper.Light.Background;
            lblStatus.ForeColor = isDark ? ThemeHelper.Dark.TextSecondary : ThemeHelper.Light.TextSecondary;
        }

        private void UpdateStatus(string message) => lblStatus.Text = message;

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
            if (_settingsService.Settings.AutoSave)
                _chatService.SaveCurrentSession();
            _settingsService.Save();
        }
    }
}
