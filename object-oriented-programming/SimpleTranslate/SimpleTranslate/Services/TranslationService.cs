using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace SimpleTranslate.Services
{
    /// <summary>
    /// Service class for handling text translation using Google Translate API.
    /// </summary>
    public class TranslationService : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://translate.googleapis.com/translate_a/single";
        private bool _disposed;

        public TranslationService()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
            // Set user agent to avoid being blocked
            _httpClient.DefaultRequestHeaders.Add("User-Agent", 
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36");
        }

        /// <summary>
        /// Translates the given text from source language to target language.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="fromLang">Source language code (e.g., "en", "tr", "auto").</param>
        /// <param name="toLang">Target language code (e.g., "en", "tr").</param>
        /// <returns>Translated text or error message.</returns>
        public async Task<string> TranslateAsync(string text, string fromLang, string toLang)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            try
            {
                // URL-encode the input text
                string encodedText = HttpUtility.UrlEncode(text);

                // Build the request URL
                string url = $"{BaseUrl}?client=gtx&sl={fromLang}&tl={toLang}&dt=t&q={encodedText}";

                // Make the HTTP request
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                return ParseTranslationResponse(jsonResponse);
            }
            catch (HttpRequestException ex)
            {
                return $"[Çeviri Hatas?: A? ba?lant?s? sa?lanamad?. {ex.Message}]";
            }
            catch (TaskCanceledException)
            {
                return "[Çeviri Hatas?: ?stek zaman a??m?na u?rad?.]";
            }
            catch (JsonException ex)
            {
                return $"[Çeviri Hatas?: Yan?t i?lenemedi. {ex.Message}]";
            }
            catch (Exception ex)
            {
                return $"[Çeviri Hatas?: {ex.Message}]";
            }
        }

        /// <summary>
        /// Parses the Google Translate JSON response and extracts translated sentences.
        /// </summary>
        /// <param name="jsonResponse">Raw JSON response from Google Translate API.</param>
        /// <returns>Concatenated translated text.</returns>
        private static string ParseTranslationResponse(string jsonResponse)
        {
            using JsonDocument doc = JsonDocument.Parse(jsonResponse);
            JsonElement root = doc.RootElement;

            // The response structure is: [[["translated","original",null,null,10],...],null,"en",...]
            // We need to get the first array and iterate through its elements
            if (root.ValueKind != JsonValueKind.Array || root.GetArrayLength() == 0)
            {
                return "[Çeviri Hatas?: Beklenmeyen yan?t format?]";
            }

            JsonElement translationsArray = root[0];
            if (translationsArray.ValueKind != JsonValueKind.Array)
            {
                return "[Çeviri Hatas?: Çeviri verisi bulunamad?]";
            }

            // Build the translated text by joining all sentence translations
            var translatedText = new System.Text.StringBuilder();
            foreach (JsonElement sentence in translationsArray.EnumerateArray())
            {
                if (sentence.ValueKind == JsonValueKind.Array && sentence.GetArrayLength() > 0)
                {
                    JsonElement translatedPart = sentence[0];
                    if (translatedPart.ValueKind == JsonValueKind.String)
                    {
                        translatedText.Append(translatedPart.GetString());
                    }
                }
            }

            string result = translatedText.ToString();
            return string.IsNullOrEmpty(result) ? "[Çeviri sonucu bo?]" : result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
