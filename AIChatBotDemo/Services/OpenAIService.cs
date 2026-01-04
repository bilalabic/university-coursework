using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Chat;
using AIChatBotDemo.Models;
using AppChatMessage = AIChatBotDemo.Models.ChatMessage;

namespace AIChatBotDemo.Services
{
    public class OpenAIService
    {
        private readonly string _apiKey;

        public bool IsEnabled => !string.IsNullOrEmpty(_apiKey);

        public OpenAIService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<(bool Success, string Message)> TestConnectionAsync()
        {
            if (string.IsNullOrEmpty(_apiKey))
                return (false, "API key boş");

            try
            {
                var client = new ChatClient("gpt-4o-mini", _apiKey);
                var response = await client.CompleteChatAsync("Say OK");
                
                if (response?.Value != null)
                    return (true, "Bağlantı başarılı!");
                
                return (false, "Yanıt alınamadı");
            }
            catch (Exception ex)
            {
                return (false, $"Hata: {ex.Message}");
            }
        }

        public async Task<LLMResponse> SendMessageAsync(List<AppChatMessage> messages, string model, double temperature, int maxTokens, CancellationToken ct = default)
        {
            try
            {
                var client = new ChatClient(model, _apiKey);
                var chatMessages = ConvertMessages(messages);
                var options = new ChatCompletionOptions 
                { 
                    Temperature = (float)temperature, 
                    MaxOutputTokenCount = maxTokens 
                };

                var response = await client.CompleteChatAsync(chatMessages, options, ct);
                var content = response.Value.Content
                    .FirstOrDefault(c => c.Kind == ChatMessageContentPartKind.Text)?.Text ?? "";

                return new LLMResponse
                {
                    Success = true,
                    Content = content,
                    Model = model,
                    Tokens = new TokenUsage
                    {
                        PromptTokens = response.Value.Usage.InputTokenCount,
                        CompletionTokens = response.Value.Usage.OutputTokenCount
                    }
                };
            }
            catch (Exception ex) 
            { 
                return LLMResponse.Fail(ex.Message); 
            }
        }

        public async IAsyncEnumerable<StreamChunk> StreamMessageAsync(
            List<AppChatMessage> messages, 
            string model, 
            double temperature, 
            int maxTokens, 
            [EnumeratorCancellation] CancellationToken ct = default)
        {
            ChatClient? client = null;
            string? initError = null;
            
            try
            {
                client = new ChatClient(model, _apiKey);
            }
            catch (Exception ex)
            {
                initError = ex.Message;
            }

            if (initError != null)
            {
                yield return new StreamChunk { Error = initError, IsComplete = true };
                yield break;
            }

            var chatMessages = ConvertMessages(messages);
            var options = new ChatCompletionOptions 
            { 
                Temperature = (float)temperature, 
                MaxOutputTokenCount = maxTokens 
            };

            await foreach (var update in client!.CompleteChatStreamingAsync(chatMessages, options, ct))
            {
                foreach (var part in update.ContentUpdate)
                {
                    if (part.Kind == ChatMessageContentPartKind.Text)
                        yield return new StreamChunk { Content = part.Text };
                }
            }
            yield return new StreamChunk { IsComplete = true };
        }

        private List<OpenAI.Chat.ChatMessage> ConvertMessages(List<AppChatMessage> messages)
        {
            var result = new List<OpenAI.Chat.ChatMessage>();
            
            foreach (var msg in messages)
            {
                if (msg.Role == "system") 
                {
                    result.Add(new SystemChatMessage(msg.Content));
                }
                else if (msg.Role == "user")
                {
                    if (msg.HasImages)
                    {
                        var parts = new List<ChatMessageContentPart> 
                        { 
                            ChatMessageContentPart.CreateTextPart(msg.Content) 
                        };
                        
                        foreach (var img in msg.Images)
                        {
                            var data = BinaryData.FromBytes(Convert.FromBase64String(img));
                            parts.Add(ChatMessageContentPart.CreateImagePart(data, "image/png"));
                        }
                        result.Add(new UserChatMessage(parts));
                    }
                    else 
                    {
                        result.Add(new UserChatMessage(msg.Content));
                    }
                }
                else if (msg.Role == "assistant") 
                {
                    result.Add(new AssistantChatMessage(msg.Content));
                }
            }
            return result;
        }
    }
}
