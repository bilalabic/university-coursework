using System;
using System.IO;
using Newtonsoft.Json;
using AIChatBotDemo.Models;
using AIChatBotDemo.Helpers;

namespace AIChatBotDemo.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;
        private AppSettings _settings;

        public AppSettings Settings => _settings;

        public SettingsService()
        {
            var appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AIChatBotDemo");
            Directory.CreateDirectory(appData);
            _settingsPath = Path.Combine(appData, "settings.json");
            _settings = new AppSettings();
            Load();
        }

        public void Load()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var json = File.ReadAllText(_settingsPath);
                    _settings = JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
                }
            }
            catch { _settings = new AppSettings(); }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(_settingsPath, json);
        }

        public void SetOpenAIKey(string apiKey)
        {
            _settings.OpenAI.EncryptedApiKey = EncryptionHelper.Encrypt(apiKey);
            _settings.OpenAI.IsEnabled = !string.IsNullOrEmpty(apiKey);
        }

        public string GetOpenAIKey() => EncryptionHelper.Decrypt(_settings.OpenAI.EncryptedApiKey);

        public void SetGeminiKey(string apiKey)
        {
            _settings.Gemini.EncryptedApiKey = EncryptionHelper.Encrypt(apiKey);
            _settings.Gemini.IsEnabled = !string.IsNullOrEmpty(apiKey);
        }

        public string GetGeminiKey() => EncryptionHelper.Decrypt(_settings.Gemini.EncryptedApiKey);
    }
}
