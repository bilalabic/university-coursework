using System;
using System.Collections.Generic;

namespace AIChatBotDemo.Models
{
    /// <summary>
    /// Tek bir chat mesajını temsil eder
    /// </summary>
    public class ChatMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Role { get; set; } = "user";
        public string Content { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string? Model { get; set; }
        public int TokenCount { get; set; }
        public bool IsEdited { get; set; }

        public bool IsUser => Role == "user";
        public bool IsAssistant => Role == "assistant";
        public bool HasImages => Images.Count > 0;
    }
}
