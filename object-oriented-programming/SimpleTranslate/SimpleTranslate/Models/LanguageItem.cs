namespace SimpleTranslate.Models
{
    /// <summary>
    /// Represents a supported language with its code and display name.
    /// </summary>
    public class LanguageItem
    {
        public string Code { get; }
        public string DisplayName { get; }

        public LanguageItem(string code, string displayName)
        {
            Code = code;
            DisplayName = displayName;
        }

        public override string ToString() => DisplayName;

        public static LanguageItem[] GetSupportedLanguages()
        {
            return new LanguageItem[]
            {
                new LanguageItem("auto", "Auto Detect"),
                new LanguageItem("en", "English"),
                new LanguageItem("tr", "Turkish"),
                new LanguageItem("de", "German"),
                new LanguageItem("fr", "French"),
                new LanguageItem("es", "Spanish"),
                new LanguageItem("it", "Italian"),
                new LanguageItem("ru", "Russian"),
                new LanguageItem("ar", "Arabic"),
                new LanguageItem("ja", "Japanese"),
                new LanguageItem("ko", "Korean"),
                new LanguageItem("zh", "Chinese"),
                new LanguageItem("pt", "Portuguese"),
                new LanguageItem("nl", "Dutch"),
                new LanguageItem("pl", "Polish"),
                new LanguageItem("sv", "Swedish"),
                new LanguageItem("no", "Norwegian"),
                new LanguageItem("da", "Danish"),
                new LanguageItem("fi", "Finnish"),
                new LanguageItem("el", "Greek"),
                new LanguageItem("cs", "Czech"),
                new LanguageItem("hu", "Hungarian"),
                new LanguageItem("ro", "Romanian"),
                new LanguageItem("bg", "Bulgarian"),
                new LanguageItem("uk", "Ukrainian")
            };
        }

        public static LanguageItem[] GetTargetLanguages()
        {
            return new LanguageItem[]
            {
                new LanguageItem("en", "English"),
                new LanguageItem("tr", "Turkish"),
                new LanguageItem("de", "German"),
                new LanguageItem("fr", "French"),
                new LanguageItem("es", "Spanish"),
                new LanguageItem("it", "Italian"),
                new LanguageItem("ru", "Russian"),
                new LanguageItem("ar", "Arabic"),
                new LanguageItem("ja", "Japanese"),
                new LanguageItem("ko", "Korean"),
                new LanguageItem("zh", "Chinese"),
                new LanguageItem("pt", "Portuguese"),
                new LanguageItem("nl", "Dutch"),
                new LanguageItem("pl", "Polish"),
                new LanguageItem("sv", "Swedish"),
                new LanguageItem("no", "Norwegian"),
                new LanguageItem("da", "Danish"),
                new LanguageItem("fi", "Finnish"),
                new LanguageItem("el", "Greek"),
                new LanguageItem("cs", "Czech"),
                new LanguageItem("hu", "Hungarian"),
                new LanguageItem("ro", "Romanian"),
                new LanguageItem("bg", "Bulgarian"),
                new LanguageItem("uk", "Ukrainian")
            };
        }
    }
}
