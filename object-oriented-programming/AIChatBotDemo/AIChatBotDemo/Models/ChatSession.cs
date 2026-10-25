using System;
using System.Collections.Generic;
using System.Linq;

namespace AIChatBotDemo.Models
{
    /// <summary>
    /// Bir sohbet oturumunu temsil eder
    /// </summary>
    public class ChatSession
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Yeni Sohbet";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Model { get; set; } = "gpt-4o";
        public List<ChatMessage> Messages { get; set; } = new();
        public string? SystemPrompt { get; set; }

        public int TotalTokens => Messages.Sum(m => m.TokenCount);
        public int MessageCount => Messages.Count;

        public void GenerateTitle()
        {
            var firstUserMessage = Messages.FirstOrDefault(m => m.IsUser);
            if (firstUserMessage != null)
            {
                var content = firstUserMessage.Content;
                Title = content.Length > 50 ? content.Substring(0, 47) + "..." : content;
            }
        }

        public void AddMessage(ChatMessage message)
        {
            Messages.Add(message);
            UpdatedAt = DateTime.Now;
            if (Messages.Count == 1 && message.IsUser)
                GenerateTitle();
        }

        public ChatMessage? GetLastMessage() => Messages.LastOrDefault();

        public void Clear()
        {
            Messages.Clear();
            Title = "Yeni Sohbet";
            UpdatedAt = DateTime.Now;
        }
    }
}
