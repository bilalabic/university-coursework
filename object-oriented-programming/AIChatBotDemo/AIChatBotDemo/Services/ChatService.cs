using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using AIChatBotDemo.Models;

namespace AIChatBotDemo.Services
{
    public class ChatService
    {
        private readonly string _chatsFolder;
        private ChatSession _currentSession;
        private List<ChatSession> _sessions;

        public ChatSession CurrentSession => _currentSession;
        public IReadOnlyList<ChatSession> Sessions => _sessions.AsReadOnly();

        public event EventHandler<ChatSession>? SessionChanged;
        public event EventHandler<ChatMessage>? MessageAdded;

        public ChatService()
        {
            var appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AIChatBotDemo", "chats");
            Directory.CreateDirectory(appData);
            _chatsFolder = appData;
            _sessions = new List<ChatSession>();
            _currentSession = new ChatSession();
            LoadSessions();
            if (_sessions.Count == 0) NewSession();
            else _currentSession = _sessions.First();
        }

        public ChatSession NewSession(string? title = null)
        {
            _currentSession = new ChatSession { Title = title ?? "Yeni Sohbet" };
            _sessions.Insert(0, _currentSession);
            SessionChanged?.Invoke(this, _currentSession);
            return _currentSession;
        }

        public void SwitchSession(string sessionId)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session != null)
            {
                _currentSession = session;
                SessionChanged?.Invoke(this, _currentSession);
            }
        }

        public void AddMessage(ChatMessage message)
        {
            _currentSession.AddMessage(message);
            MessageAdded?.Invoke(this, message);
        }

        public void SaveCurrentSession() => SaveSession(_currentSession);

        public void SaveSession(ChatSession session)
        {
            var filePath = Path.Combine(_chatsFolder, $"{session.Id}.json");
            var json = JsonConvert.SerializeObject(session, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void DeleteSession(string sessionId)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session != null)
            {
                _sessions.Remove(session);
                var filePath = Path.Combine(_chatsFolder, $"{sessionId}.json");
                if (File.Exists(filePath)) File.Delete(filePath);
                if (_currentSession.Id == sessionId)
                    _currentSession = _sessions.FirstOrDefault() ?? NewSession();
            }
        }

        private void LoadSessions()
        {
            foreach (var file in Directory.GetFiles(_chatsFolder, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var session = JsonConvert.DeserializeObject<ChatSession>(json);
                    if (session != null) _sessions.Add(session);
                }
                catch { }
            }
            _sessions = _sessions.OrderByDescending(s => s.UpdatedAt).ToList();
        }
    }
}
