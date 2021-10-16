using System.Text.Json.Serialization;

namespace TelegramBot
{
    public partial class QuotesCollection
    {
        [JsonPropertyName("quotes")]
        public Quote[] Quotes { get; set; }
    }

    public partial class Quote
    {
        [JsonPropertyName("quote")]
        public string Text { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}
