using DevExpress.XtraEditors;
using DevExpress.Utils;
using SimpleTranslate.Models;
using SimpleTranslate.Services;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTranslate
{
    /// <summary>
    /// Main form for the SimpleTranslate application.
    /// Provides translation, image search, and text-to-speech functionality.
    /// </summary>
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        #region Private Fields

        private readonly TranslationService _translationService;
        private readonly ImageSearchService _imageSearchService;
        private readonly StatsManager _statsManager;
        private readonly QuoteService _quoteService;
        private readonly HttpClient _imageHttpClient;
        private SpeechSynthesizer? _speechSynthesizer;

        // Color Palette
        private static readonly Color PrimaryColor = Color.FromArgb(0, 122, 204);
        private static readonly Color SecondaryColor = Color.FromArgb(40, 167, 69);
        private static readonly Color AccentColor = Color.FromArgb(255, 193, 7);
        private static readonly Color InfoColor = Color.FromArgb(23, 162, 184);
        private static readonly Color PurpleColor = Color.FromArgb(103, 58, 183);
        private static readonly Color LightGray = Color.FromArgb(248, 249, 250);
        private static readonly Color DarkText = Color.FromArgb(33, 37, 41);
        private static readonly Color MutedText = Color.FromArgb(108, 117, 125);

        #endregion

        #region Constructor

        public Main()
        {
            InitializeComponent();

            _translationService = new TranslationService();
            _imageSearchService = new ImageSearchService();
            _statsManager = new StatsManager();
            _quoteService = new QuoteService();
            _imageHttpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

            WireUpEventHandlers();
            ApplyCustomStyling();
        }

        #endregion

        #region Form Events

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeLanguageComboBoxes();
            LoadQuoteOfTheDay();
            UpdateStatsDisplay();
            memoInput.Focus();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _translationService?.Dispose();
            _imageSearchService?.Dispose();
            _imageHttpClient?.Dispose();
            _speechSynthesizer?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion

        #region Initialization

        private void WireUpEventHandlers()
        {
            btnTranslate.Click += BtnTranslate_Click;
            btnSwap.Click += BtnSwap_Click;
            btnClear.Click += BtnClear_Click;
            btnCopy.Click += BtnCopy_Click;
            btnSpeak.Click += BtnSpeak_Click;
        }

        /// <summary>
        /// Applies custom styling to all controls for a modern look.
        /// </summary>
        private void ApplyCustomStyling()
        {
            // Form
            this.BackColor = LightGray;
            this.FormBorderEffect = FormBorderEffect.Shadow;

            // Translate Button - Primary
            btnTranslate.Appearance.BackColor = PrimaryColor;
            btnTranslate.Appearance.BackColor2 = Color.FromArgb(0, 86, 163);
            btnTranslate.Appearance.ForeColor = Color.White;
            btnTranslate.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTranslate.Appearance.Options.UseBackColor = true;
            btnTranslate.Appearance.Options.UseForeColor = true;
            btnTranslate.Appearance.Options.UseFont = true;
            btnTranslate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // Swap Button
            btnSwap.Appearance.BackColor = MutedText;
            btnSwap.Appearance.ForeColor = Color.White;
            btnSwap.Appearance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnSwap.Appearance.Options.UseBackColor = true;
            btnSwap.Appearance.Options.UseForeColor = true;
            btnSwap.Appearance.Options.UseFont = true;
            btnSwap.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // Clear Button
            btnClear.Appearance.BackColor = Color.White;
            btnClear.Appearance.ForeColor = MutedText;
            btnClear.Appearance.BorderColor = Color.FromArgb(206, 212, 218);
            btnClear.Appearance.Font = new Font("Segoe UI", 12F);
            btnClear.Appearance.Options.UseBackColor = true;
            btnClear.Appearance.Options.UseForeColor = true;
            btnClear.Appearance.Options.UseBorderColor = true;
            btnClear.Appearance.Options.UseFont = true;

            // Copy Button - Green
            btnCopy.Appearance.BackColor = SecondaryColor;
            btnCopy.Appearance.ForeColor = Color.White;
            btnCopy.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCopy.Appearance.Options.UseBackColor = true;
            btnCopy.Appearance.Options.UseForeColor = true;
            btnCopy.Appearance.Options.UseFont = true;
            btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // Speak Button - Info
            btnSpeak.Appearance.BackColor = InfoColor;
            btnSpeak.Appearance.ForeColor = Color.White;
            btnSpeak.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSpeak.Appearance.Options.UseBackColor = true;
            btnSpeak.Appearance.Options.UseForeColor = true;
            btnSpeak.Appearance.Options.UseFont = true;
            btnSpeak.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;

            // Source Group - Blue
            grpSource.Appearance.BackColor = Color.White;
            grpSource.Appearance.BorderColor = PrimaryColor;
            grpSource.Appearance.Options.UseBackColor = true;
            grpSource.Appearance.Options.UseBorderColor = true;
            grpSource.AppearanceCaption.ForeColor = PrimaryColor;
            grpSource.AppearanceCaption.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpSource.AppearanceCaption.Options.UseForeColor = true;
            grpSource.AppearanceCaption.Options.UseFont = true;

            // Target Group - Green
            grpTarget.Appearance.BackColor = Color.White;
            grpTarget.Appearance.BorderColor = SecondaryColor;
            grpTarget.Appearance.Options.UseBackColor = true;
            grpTarget.Appearance.Options.UseBorderColor = true;
            grpTarget.AppearanceCaption.ForeColor = SecondaryColor;
            grpTarget.AppearanceCaption.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpTarget.AppearanceCaption.Options.UseForeColor = true;
            grpTarget.AppearanceCaption.Options.UseFont = true;

            // Quote Group - Amber
            grpQuote.Appearance.BackColor = Color.FromArgb(255, 248, 225);
            grpQuote.Appearance.BorderColor = AccentColor;
            grpQuote.Appearance.Options.UseBackColor = true;
            grpQuote.Appearance.Options.UseBorderColor = true;
            grpQuote.AppearanceCaption.ForeColor = Color.FromArgb(133, 100, 4);
            grpQuote.AppearanceCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpQuote.AppearanceCaption.Options.UseForeColor = true;
            grpQuote.AppearanceCaption.Options.UseFont = true;

            // Stats Group - Purple
            grpStats.Appearance.BackColor = Color.FromArgb(237, 231, 246);
            grpStats.Appearance.BorderColor = PurpleColor;
            grpStats.Appearance.Options.UseBackColor = true;
            grpStats.Appearance.Options.UseBorderColor = true;
            grpStats.AppearanceCaption.ForeColor = PurpleColor;
            grpStats.AppearanceCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpStats.AppearanceCaption.Options.UseForeColor = true;
            grpStats.AppearanceCaption.Options.UseFont = true;

            // Input MemoEdit
            memoInput.Properties.Appearance.BackColor = Color.White;
            memoInput.Properties.Appearance.ForeColor = DarkText;
            memoInput.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            memoInput.Properties.Appearance.Options.UseBackColor = true;
            memoInput.Properties.Appearance.Options.UseForeColor = true;
            memoInput.Properties.Appearance.Options.UseFont = true;
            memoInput.Properties.NullValuePromptShowForEmptyValue = true;

            // Output MemoEdit
            memoOutput.Properties.Appearance.BackColor = Color.FromArgb(248, 255, 248);
            memoOutput.Properties.Appearance.ForeColor = DarkText;
            memoOutput.Properties.Appearance.Font = new Font("Segoe UI", 14F);
            memoOutput.Properties.Appearance.Options.UseBackColor = true;
            memoOutput.Properties.Appearance.Options.UseForeColor = true;
            memoOutput.Properties.Appearance.Options.UseFont = true;
            memoOutput.Properties.AppearanceReadOnly.BackColor = Color.FromArgb(248, 255, 248);
            memoOutput.Properties.AppearanceReadOnly.Options.UseBackColor = true;

            // ComboBoxes
            cmbSourceLanguage.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            cmbSourceLanguage.Properties.Appearance.Options.UseFont = true;
            cmbTargetLanguage.Properties.Appearance.Font = new Font("Segoe UI", 12F);
            cmbTargetLanguage.Properties.Appearance.Options.UseFont = true;

            // Labels
            lblQuote.Appearance.ForeColor = Color.FromArgb(133, 100, 4);
            lblQuote.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblQuote.Appearance.Options.UseForeColor = true;
            lblQuote.Appearance.Options.UseFont = true;

            lblStats.Appearance.ForeColor = PurpleColor;
            lblStats.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStats.Appearance.Options.UseForeColor = true;
            lblStats.Appearance.Options.UseFont = true;

            // Picture Edit
            picImage.Properties.Appearance.BackColor = Color.FromArgb(240, 240, 240);
            picImage.Properties.Appearance.Options.UseBackColor = true;
            picImage.BackColor = Color.FromArgb(240, 240, 240);
            picImage.Properties.NullText = "Related image will appear here";
        }

        private void InitializeLanguageComboBoxes()
        {
            cmbSourceLanguage.Properties.Items.Clear();
            foreach (var lang in LanguageItem.GetSupportedLanguages())
            {
                cmbSourceLanguage.Properties.Items.Add(lang);
            }
            cmbSourceLanguage.SelectedIndex = 0;

            cmbTargetLanguage.Properties.Items.Clear();
            foreach (var lang in LanguageItem.GetTargetLanguages())
            {
                cmbTargetLanguage.Properties.Items.Add(lang);
            }
            cmbTargetLanguage.SelectedIndex = 1;
        }

        private void LoadQuoteOfTheDay()
        {
            try
            {
                lblQuote.Text = _quoteService.GetFormattedQuote();
            }
            catch
            {
                lblQuote.Text = "Language is the road map of a culture.";
            }
        }

        private void UpdateStatsDisplay()
        {
            lblStats.Text = _statsManager.GetTopLanguageInfo();
        }

        #endregion

        #region Button Event Handlers

        private async void BtnTranslate_Click(object? sender, EventArgs e)
        {
            string inputText = memoInput.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                ShowWarning("Please enter text to translate.");
                memoInput.Focus();
                return;
            }

            var sourceLanguage = cmbSourceLanguage.SelectedItem as LanguageItem;
            var targetLanguage = cmbTargetLanguage.SelectedItem as LanguageItem;

            if (sourceLanguage == null || targetLanguage == null)
            {
                ShowWarning("Please select source and target languages.");
                return;
            }

            SetUIEnabled(false);
            memoOutput.Text = "Translating...";
            picImage.Image = null;

            try
            {
                string translatedText = await _translationService.TranslateAsync(
                    inputText,
                    sourceLanguage.Code,
                    targetLanguage.Code
                );

                memoOutput.Text = translatedText;
                _statsManager.UpdateStats(targetLanguage.Code);
                UpdateStatsDisplay();

                await LoadRelatedImageAsync(translatedText);
            }
            catch (Exception ex)
            {
                memoOutput.Text = $"Translation error: {ex.Message}";
            }
            finally
            {
                SetUIEnabled(true);
            }
        }

        private void BtnSwap_Click(object? sender, EventArgs e)
        {
            int sourceIndex = cmbSourceLanguage.SelectedIndex;
            int targetIndex = cmbTargetLanguage.SelectedIndex;
            string inputText = memoInput.Text;
            string outputText = memoOutput.Text;

            memoInput.Text = outputText;
            memoOutput.Text = inputText;

            if (sourceIndex == 0)
            {
                cmbSourceLanguage.SelectedIndex = targetIndex + 1;
                cmbTargetLanguage.SelectedIndex = 0;
            }
            else
            {
                cmbSourceLanguage.SelectedIndex = targetIndex + 1;
                cmbTargetLanguage.SelectedIndex = sourceIndex - 1;
            }

            picImage.Image = null;
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            memoInput.Text = string.Empty;
            memoOutput.Text = string.Empty;
            picImage.Image = null;
            cmbSourceLanguage.SelectedIndex = 0;
            cmbTargetLanguage.SelectedIndex = 1;
            memoInput.Focus();
        }

        private void BtnCopy_Click(object? sender, EventArgs e)
        {
            string outputText = memoOutput.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(outputText))
            {
                ShowWarning("No text to copy.");
                return;
            }

            try
            {
                Clipboard.SetText(outputText);
                ShowSuccess("Text copied to clipboard!");
            }
            catch (Exception ex)
            {
                ShowWarning($"Copy error: {ex.Message}");
            }
        }

        private void BtnSpeak_Click(object? sender, EventArgs e)
        {
            string outputText = memoOutput.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(outputText))
            {
                ShowWarning("No text to speak.");
                return;
            }

            try
            {
                _speechSynthesizer ??= new SpeechSynthesizer();
                _speechSynthesizer.SpeakAsyncCancelAll();

                var targetLanguage = cmbTargetLanguage.SelectedItem as LanguageItem;
                if (targetLanguage != null)
                {
                    TrySetVoiceForLanguage(targetLanguage.Code);
                }

                _speechSynthesizer.SpeakAsync(outputText);
            }
            catch (Exception ex)
            {
                ShowWarning($"Speech error: {ex.Message}");
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Generates an AI image based on the translated text using Hugging Face API.
        /// </summary>
        private async Task LoadRelatedImageAsync(string translatedText)
        {
            try
            {
                // Update UI to show image generation is in progress
                picImage.Properties.NullText = "Generating AI image... (this may take up to 2 minutes)";
                picImage.Image = null;
                picImage.Refresh();

                // Generate AI image using Hugging Face Stable Diffusion
                byte[]? imageBytes = await _imageSearchService.GetImageBytesAsync(translatedText);

                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using var ms = new MemoryStream(imageBytes);
                    picImage.Image = Image.FromStream(ms);
                    picImage.Properties.NullText = "Related image will appear here";
                }
                else
                {
                    // Show error message from service
                    string errorMsg = _imageSearchService.LastError ?? "Unknown error";
                    picImage.Properties.NullText = $"Image generation failed: {errorMsg}";
                    picImage.Image = null;
                    
                    // Log to debug output
                    System.Diagnostics.Debug.WriteLine($"[ImageSearchService] Error: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                picImage.Properties.NullText = $"Error: {ex.Message}";
                picImage.Image = null;
                System.Diagnostics.Debug.WriteLine($"[LoadRelatedImageAsync] Exception: {ex}");
            }
        }

        private void TrySetVoiceForLanguage(string languageCode)
        {
            if (_speechSynthesizer == null) return;

            try
            {
                foreach (var voice in _speechSynthesizer.GetInstalledVoices())
                {
                    if (voice.VoiceInfo.Culture.Name.StartsWith(languageCode, StringComparison.OrdinalIgnoreCase))
                    {
                        _speechSynthesizer.SelectVoice(voice.VoiceInfo.Name);
                        return;
                    }
                }
                _speechSynthesizer.SelectVoiceByHints(VoiceGender.NotSet);
            }
            catch { }
        }

        private void SetUIEnabled(bool enabled)
        {
            btnTranslate.Enabled = enabled;
            btnSwap.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnCopy.Enabled = enabled;
            btnSpeak.Enabled = enabled;
            memoInput.Enabled = enabled;
            cmbSourceLanguage.Enabled = enabled;
            cmbTargetLanguage.Enabled = enabled;

            if (enabled)
            {
                btnTranslate.Text = "TRANSLATE";
                btnTranslate.Appearance.BackColor = PrimaryColor;
                btnTranslate.Appearance.BackColor2 = Color.FromArgb(0, 86, 163);
            }
            else
            {
                btnTranslate.Text = "Translating...";
                btnTranslate.Appearance.BackColor = MutedText;
                btnTranslate.Appearance.BackColor2 = Color.FromArgb(90, 98, 104);
            }
        }

        private void ShowWarning(string message)
        {
            XtraMessageBox.Show(this, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowSuccess(string message)
        {
            XtraMessageBox.Show(this, message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}