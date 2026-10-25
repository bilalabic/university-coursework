using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTranslate.Services
{
    /// <summary>
    /// In-memory statistics manager for tracking translation usage during the session.
    /// </summary>
    public class StatsManager
    {
        private readonly Dictionary<string, int> _languageUsageCount;
        private int _totalTranslations;
        private readonly Dictionary<string, string> _languageDisplayNames;

        public StatsManager()
        {
            _languageUsageCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            _totalTranslations = 0;

            _languageDisplayNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "en", "English" },
                { "tr", "Turkish" },
                { "de", "German" },
                { "fr", "French" },
                { "es", "Spanish" },
                { "it", "Italian" },
                { "ru", "Russian" },
                { "ar", "Arabic" },
                { "ja", "Japanese" },
                { "ko", "Korean" },
                { "zh", "Chinese" },
                { "pt", "Portuguese" },
                { "nl", "Dutch" },
                { "pl", "Polish" },
                { "auto", "Auto" }
            };
        }

        public void UpdateStats(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode)) return;

            _totalTranslations++;

            if (_languageUsageCount.ContainsKey(languageCode))
                _languageUsageCount[languageCode]++;
            else
                _languageUsageCount[languageCode] = 1;
        }

        public string GetTopLanguageInfo()
        {
            if (_totalTranslations == 0)
                return "No translations yet.";

            var topLanguage = _languageUsageCount
                .OrderByDescending(kvp => kvp.Value)
                .FirstOrDefault();

            string languageName = GetLanguageDisplayName(topLanguage.Key);
            int usagePercentage = (int)Math.Round((double)topLanguage.Value / _totalTranslations * 100);

            return $"Total: {_totalTranslations} translations | Top: {languageName} ({topLanguage.Value}x, {usagePercentage}%)";
        }

        public string GetDetailedStats()
        {
            if (_totalTranslations == 0)
                return "No translations yet.";

            var sortedLanguages = _languageUsageCount
                .OrderByDescending(kvp => kvp.Value)
                .Take(5);

            var statsLines = sortedLanguages.Select((kvp, index) =>
            {
                string medal = index switch { 0 => "#1", 1 => "#2", 2 => "#3", _ => $"#{index + 1}" };
                string langName = GetLanguageDisplayName(kvp.Key);
                return $"{medal} {langName}: {kvp.Value}";
            });

            return $"Total: {_totalTranslations} translations\n" + string.Join(" | ", statsLines);
        }

        public int TotalTranslations => _totalTranslations;

        public void Reset()
        {
            _languageUsageCount.Clear();
            _totalTranslations = 0;
        }

        private string GetLanguageDisplayName(string languageCode)
        {
            return _languageDisplayNames.TryGetValue(languageCode, out string? displayName) 
                ? displayName 
                : languageCode.ToUpperInvariant();
        }
    }
}
