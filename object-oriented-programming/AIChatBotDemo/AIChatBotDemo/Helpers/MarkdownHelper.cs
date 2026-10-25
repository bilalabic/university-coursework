using System.Collections.Generic;
using System.Text;
using Markdig;
using AIChatBotDemo.Models;

namespace AIChatBotDemo.Helpers
{
    public static class MarkdownHelper
    {
        private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseEmojiAndSmiley()
            .UseTaskLists()
            .UsePipeTables()
            .Build();

        public static string ToHtml(string markdown)
        {
            if (string.IsNullOrEmpty(markdown)) return string.Empty;
            return Markdown.ToHtml(markdown, Pipeline);
        }

        public static string CreateHtmlPage(string content, bool isDark)
        {
            var css = ThemeHelper.GetChatCss(isDark);
            return $@"<!DOCTYPE html><html><head><meta charset='utf-8'><style>{css}</style></head><body>{content}</body></html>";
        }

        public static string MessagesToHtml(List<ChatMessage> messages, bool isDark)
        {
            var sb = new StringBuilder();
            foreach (var msg in messages)
            {
                var cssClass = msg.IsUser ? "user" : "assistant";
                var content = ToHtml(msg.Content);
                
                // Görseller varsa ekle
                if (msg.HasImages)
                {
                    foreach (var img in msg.Images)
                    {
                        content = $"<img src='data:image/png;base64,{img}' /><br/>" + content;
                    }
                }
                
                sb.AppendLine($"<div class='message {cssClass}'>{content}<div class='timestamp'>{msg.Timestamp:HH:mm}</div></div>");
            }
            return CreateHtmlPage(sb.ToString(), isDark);
        }
    }
}
