using System;
using System.Collections.Generic;

namespace SimpleTranslate.Services
{
    /// <summary>
    /// Service class that provides random motivational quotes about language learning.
    /// </summary>
    public class QuoteService
    {
        private readonly List<Quote> _quotes;
        private readonly Random _random;

        public QuoteService()
        {
            _random = new Random();
            
            _quotes = new List<Quote>
            {
                new Quote(
                    "One language sets you in a corridor for life. Two languages open every door along the way.",
                    "Frank Smith"
                ),
                new Quote(
                    "The limits of my language mean the limits of my world.",
                    "Ludwig Wittgenstein"
                ),
                new Quote(
                    "To have another language is to possess a second soul.",
                    "Charlemagne"
                ),
                new Quote(
                    "Language is the road map of a culture.",
                    "Rita Mae Brown"
                ),
                new Quote(
                    "With every language you learn, you gain a new life.",
                    "Czech Proverb"
                ),
                new Quote(
                    "Learning another language is not only learning different words, but learning another way to think.",
                    "Flora Lewis"
                ),
                new Quote(
                    "A different language is a different vision of life.",
                    "Federico Fellini"
                ),
                new Quote(
                    "Language is the key to the heart of people.",
                    "Ahmed Deedat"
                ),
                new Quote(
                    "You can never understand one language until you understand at least two.",
                    "Geoffrey Willans"
                ),
                new Quote(
                    "Language is the dress of thought.",
                    "Samuel Johnson"
                ),
                new Quote(
                    "The more languages you know, the more you are human.",
                    "Tomáš Garrigue Masaryk"
                ),
                new Quote(
                    "If you talk to a man in a language he understands, it goes to his head. If you talk to him in his language, it goes to his heart.",
                    "Nelson Mandela"
                )
            };
        }

        public Quote GetRandomQuote()
        {
            return _quotes[_random.Next(_quotes.Count)];
        }

        public string GetFormattedQuote()
        {
            Quote quote = GetRandomQuote();
            return $"\"{quote.Text}\" - {quote.Author}";
        }

        public int QuoteCount => _quotes.Count;
    }

    public class Quote
    {
        public string Text { get; }
        public string Author { get; }

        public Quote(string text, string author)
        {
            Text = text;
            Author = author;
        }

        public override string ToString() => $"\"{Text}\" - {Author}";
    }
}
