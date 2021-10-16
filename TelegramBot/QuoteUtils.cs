using System;
using System.IO;
using System.Text.Json;

namespace TelegramBot
{
    public class QuoteUtils
    {
        private QuotesCollection _quotesObject;

        public QuoteUtils()
        {
            LoadPhrases();
        }

        private void LoadPhrases()
        {
            var jsonString = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "phrases", "phrases.json"));
            _quotesObject = JsonSerializer.Deserialize<QuotesCollection>(jsonString);
        }

        public Quote GetQuote(Random rand)
        {
            if (_quotesObject == null || _quotesObject.Quotes.IsNullOrEmpty())
                LoadPhrases();

            return _quotesObject.Quotes.RandomElementUsing(rand);
        }
    }
}
