using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AIChatBotDemo.Models;

namespace AIChatBotDemo.Services
{
    public class GeminiService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models";

        public bool IsEnabled => !string.IsNullOrEmpty(_apiKey);

        public GeminiService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<(bool Success, string Message)> TestConnectionAsync()
        {
            if (string.IsNullOrEmpty(_apiKey))
                return (false, "API key boş");

            try
            {
                // Doğru model adı: gemini-2.0-flash
                var url = $"{BaseUrl}/gemini-2.0-flash:generateContent?key={_apiKey}";
                
                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = "Say OK" }
                            }
                        }
                    }
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PostAsync(url, content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Bağlantı başarılı!");
                }
                else
                {
                    // Hata detayını parse et
                    try
                    {
                        using var doc = JsonDocument.Parse(responseText);
                        var error = doc.RootElement.GetProperty("error");
                        var message = error.GetProperty("message").GetString();
                        return (false, $"API Hatası: {message}");
                    }
                    catch
                    {
                        return (false, $"HTTP {(int)response.StatusCode}: {responseText}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return (false, $"Bağlantı hatası: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                return (false, "Zaman aşımı - İnternet bağlantınızı kontrol edin");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public async Task<LLMResponse> SendMessageAsync(
            List<ChatMessage> messages, 
            string modelName, 
            double temperature, 
            int maxTokens, 
            CancellationToken ct = default)
        {
            try
            {
                var lastMessage = messages.LastOrDefault(m => m.Role == "user");
                if (lastMessage == null) 
                    return LLMResponse.Fail("Kullanıcı mesajı bulunamadı");

                // Model adını düzelt - Google'ın güncel model adları
                var model = modelName switch
                {
                    "gemini-2.5-flash" => "gemini-2.5-flash-preview-05-20",
                    "gemini-2.0-flash" => "gemini-2.0-flash",
                    "gemini-1.5-flash" => "gemini-1.5-flash",
                    "gemini-1.5-pro" => "gemini-1.5-pro",
                    _ => modelName
                };

                var url = $"{BaseUrl}/{model}:generateContent?key={_apiKey}";

                object requestBody;

                if (lastMessage.HasImages && lastMessage.Images.Count > 0)
                {
                    // Görsel ile istek
                    var parts = new List<object>
                    {
                        new { text = lastMessage.Content }
                    };

                    foreach (var img in lastMessage.Images)
                    {
                        parts.Add(new
                        {
                            inline_data = new
                            {
                                mime_type = "image/png",
                                data = img
                            }
                        });
                    }

                    requestBody = new
                    {
                        contents = new[]
                        {
                            new { parts = parts.ToArray() }
                        },
                        generationConfig = new
                        {
                            temperature = temperature,
                            maxOutputTokens = maxTokens
                        }
                    };
                }
                else
                {
                    // Sadece metin
                    requestBody = new
                    {
                        contents = new[]
                        {
                            new
                            {
                                parts = new[]
                                {
                                    new { text = lastMessage.Content }
                                }
                            }
                        },
                        generationConfig = new
                        {
                            temperature = temperature,
                            maxOutputTokens = maxTokens
                        }
                    };
                }

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content, ct);
                var responseText = await response.Content.ReadAsStringAsync(ct);

                if (!response.IsSuccessStatusCode)
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(responseText);
                        var error = doc.RootElement.GetProperty("error");
                        var message = error.GetProperty("message").GetString();
                        return LLMResponse.Fail($"API Hatası: {message}");
                    }
                    catch
                    {
                        return LLMResponse.Fail($"HTTP {(int)response.StatusCode}");
                    }
                }

                // Yanıtı parse et
                using var responseDoc = JsonDocument.Parse(responseText);
                var candidates = responseDoc.RootElement.GetProperty("candidates");
                var firstCandidate = candidates[0];
                var contentProp = firstCandidate.GetProperty("content");
                var partsProp = contentProp.GetProperty("parts");
                var text = partsProp[0].GetProperty("text").GetString() ?? "";

                // Token kullanımı
                int promptTokens = 0, completionTokens = 0;
                if (responseDoc.RootElement.TryGetProperty("usageMetadata", out var usage))
                {
                    if (usage.TryGetProperty("promptTokenCount", out var pt))
                        promptTokens = pt.GetInt32();
                    if (usage.TryGetProperty("candidatesTokenCount", out var ct2))
                        completionTokens = ct2.GetInt32();
                }

                return new LLMResponse
                {
                    Success = true,
                    Content = text,
                    Model = modelName,
                    Tokens = new TokenUsage
                    {
                        PromptTokens = promptTokens,
                        CompletionTokens = completionTokens
                    }
                };
            }
            catch (Exception ex)
            {
                return LLMResponse.Fail(ex.Message);
            }
        }

        public async IAsyncEnumerable<StreamChunk> StreamMessageAsync(
            List<ChatMessage> messages, 
            string modelName, 
            double temperature, 
            int maxTokens, 
            [EnumeratorCancellation] CancellationToken ct = default)
        {
            var lastMessage = messages.LastOrDefault(m => m.Role == "user");
            if (lastMessage == null)
            {
                yield return new StreamChunk { Error = "Kullanıcı mesajı bulunamadı", IsComplete = true };
                yield break;
            }

            // Model adını düzelt
            var model = modelName switch
            {
                "gemini-2.5-flash" => "gemini-2.5-flash-preview-05-20",
                "gemini-2.0-flash" => "gemini-2.0-flash",
                "gemini-1.5-flash" => "gemini-1.5-flash",
                "gemini-1.5-pro" => "gemini-1.5-pro",
                _ => modelName
            };
            var url = $"{BaseUrl}/{model}:streamGenerateContent?key={_apiKey}&alt=sse";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = lastMessage.Content }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = temperature,
                    maxOutputTokens = maxTokens
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage? response = null;
            string? httpError = null;
            
            try
            {
                response = await _httpClient.PostAsync(url, content, ct);
            }
            catch (Exception ex)
            {
                httpError = ex.Message;
            }

            if (httpError != null)
            {
                yield return new StreamChunk { Error = httpError, IsComplete = true };
                yield break;
            }

            if (!response!.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync(ct);
                yield return new StreamChunk { Error = $"HTTP {(int)response.StatusCode}: {errorText}", IsComplete = true };
                yield break;
            }

            using var stream = await response.Content.ReadAsStreamAsync(ct);
            using var reader = new System.IO.StreamReader(stream);

            while (!reader.EndOfStream && !ct.IsCancellationRequested)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(line)) continue;

                if (line.StartsWith("data: "))
                {
                    var jsonData = line.Substring(6);
                    if (jsonData == "[DONE]") break;

                    var text = ParseStreamChunk(jsonData);
                    if (!string.IsNullOrEmpty(text))
                    {
                        yield return new StreamChunk { Content = text };
                    }
                }
            }

            yield return new StreamChunk { IsComplete = true };
        }

        private string? ParseStreamChunk(string jsonData)
        {
            try
            {
                using var doc = JsonDocument.Parse(jsonData);
                
                if (doc.RootElement.TryGetProperty("candidates", out var candidates) && 
                    candidates.GetArrayLength() > 0)
                {
                    var candidate = candidates[0];
                    if (candidate.TryGetProperty("content", out var contentProp) &&
                        contentProp.TryGetProperty("parts", out var parts) &&
                        parts.GetArrayLength() > 0)
                    {
                        return parts[0].GetProperty("text").GetString();
                    }
                }
            }
            catch { }
            return null;
        }
    }
}
