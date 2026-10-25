using System.Collections.Generic;

namespace AIChatBotDemo.Models
{
    public class LLMResponse
    {
        public bool Success { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? Error { get; set; }
        public string Model { get; set; } = string.Empty;
        public TokenUsage Tokens { get; set; } = new();
        public long ResponseTimeMs { get; set; }
        public string? FinishReason { get; set; }

        public static LLMResponse Ok(string content, string model, TokenUsage? tokens = null)
            => new() { Success = true, Content = content, Model = model, Tokens = tokens ?? new() };

        public static LLMResponse Fail(string error)
            => new() { Success = false, Error = error };
    }

    public class TokenUsage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens => PromptTokens + CompletionTokens;
    }

    public class StreamChunk
    {
        public string Content { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public string? Error { get; set; }
    }

    public static class SupportedModels
    {
        public const string GPT4o = "gpt-4o";
        public const string GPT4oMini = "gpt-4o-mini";
        public const string Gemini25Flash = "gemini-2.5-flash-preview-05-20";
        public const string Gemini20Flash = "gemini-2.0-flash";

        public static List<ModelInfo> GetAllModels() => new()
        {
            new(GPT4o, "GPT-4o", "OpenAI", true, 128000),
            new(GPT4oMini, "GPT-4o Mini", "OpenAI", true, 128000),
            new(Gemini25Flash, "Gemini 2.5 Flash", "Google", true, 1000000),
            new(Gemini20Flash, "Gemini 2.0 Flash", "Google", true, 1000000),
        };
    }

    public class ModelInfo
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Provider { get; set; }
        public bool SupportsVision { get; set; }
        public int MaxTokens { get; set; }

        public ModelInfo(string id, string name, string provider, bool vision, int maxTokens)
        {
            Id = id; DisplayName = name; Provider = provider; SupportsVision = vision; MaxTokens = maxTokens;
        }
        public override string ToString() => $"{DisplayName} ({Provider})";
    }
}
