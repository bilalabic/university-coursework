# 🤖 AI ChatBot Demo

.NET 8 Windows Forms ile geliştirilmiş, çoklu LLM destekli basit bir chatbot uygulaması.

## Özellikler

- **Çoklu LLM Desteği**: OpenAI (GPT-4o) ve Google Gemini (2.0/2.5 Flash)
- **Görsel Analizi**: Resim yükleme, sürükle-bırak, Ctrl+V ile yapıştırma
- **Streaming**: Gerçek zamanlı yanıt akışı
- **Markdown**: Kod blokları ve formatlanmış metin desteği
- **Tema**: Light/Dark mod
- **Sohbet Geçmişi**: Kaydetme, yükleme, JSON/TXT export

## Kurulum

```bash
cd AIChatBotDemo/AIChatBotDemo
dotnet build
dotnet run
```

## Gereksinimler

- Windows 10/11
- .NET 8.0 Runtime
- WebView2 Runtime

## API Anahtarları

**Gemini (Ücretsiz)**: https://aistudio.google.com/apikey

**OpenAI (Ücretli)**: https://platform.openai.com/api-keys

## Proje Yapısı

```
AIChatBotDemo/
├── Forms/          # MainForm, SettingsForm, AboutForm...
├── Services/       # OpenAIService, GeminiService, ChatService...
├── Models/         # ChatMessage, ChatSession, AppSettings...
└── Helpers/        # ThemeHelper, MarkdownHelper, EncryptionHelper
```

## Kullanım

1. Ayarlar → API Ayarları'ndan key gir
2. Model seç
3. Mesaj yaz, Enter'a bas

## Lisans

MIT

---

🤖 **Yapay Zeka yardımıyla oluşturulmuştur** (Gemini, Claude ve IDE: Kiro)
