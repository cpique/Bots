using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    public class Program
    {
        private static ITelegramBotClient _botClient;
        private static Random _rand = new Random();
        private static QuoteUtils _quotesUtils = new QuoteUtils();

        public static async Task Main(string[] args)
        {
            Console.WriteLine($"Welcome to the Telegram Bot! Make sure you have updated the API key before using the bot.");

            _botClient = new TelegramBotClient(Constants.TELEGRAM_API);
            var me = await _botClient.GetMeAsync();
            Console.WriteLine($"Hi. I am {me.Id} and my name is: {me.FirstName}");

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        private static async void _botClient_OnMessage(object sender, MessageEventArgs args)
        {
            if(args.Message.Text == Constants.COMMAND)
            {
                Console.WriteLine("Message received");

                var quoteObject = _quotesUtils.GetQuote(_rand);
                var text = $"Quote: {quoteObject.Text} Author: {quoteObject.Author}";

                await _botClient.SendTextMessageAsync(chatId: args.Message.Chat.Id, text: text);
            }
        }
    }


}
