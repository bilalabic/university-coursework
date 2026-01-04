using System;

namespace AIChatBotDemo.Models
{
    public class AppSettings
    {
        // API Ayarları
        public ApiSettings OpenAI { get; set; } = new();
        public ApiSettings Gemini { get; set; } = new();

        // Model Ayarları
        public string DefaultModel { get; set; } = "gpt-4o";
        public double Temperature { get; set; } = 0.7;
        public int MaxTokens { get; set; } = 2000;
        public bool UseStreaming { get; set; } = true;

        // Genel Ayarlar
        public bool AutoSave { get; set; } = true;
        public string Language { get; set; } = "tr";

        // Görünüm Ayarları
        public string Theme { get; set; } = "light";
        public string FontFamily { get; set; } = "Segoe UI";
        public int FontSize { get; set; } = 14;

        // Pencere Ayarları
        public int WindowWidth { get; set; } = 1200;
        public int WindowHeight { get; set; } = 800;
        public bool IsMaximized { get; set; } = false;

        public string? LastSessionId { get; set; }
    }

    public class ApiSettings
    {
        public string EncryptedApiKey { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = false;
        public string DefaultModel { get; set; } = string.Empty;
    }
}
