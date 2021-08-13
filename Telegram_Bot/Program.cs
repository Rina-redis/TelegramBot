using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class Program
    {
        private static string botToken { get; set; } = "1937284167:AAGXFfqt0kcGWCbYVBYAh2G0QB2mE8vDYpQ";
        private static TelegramBotClient currentClient;
        private static long chatId;

        [Obsolete]
        static void Main(string[] args)
        {
            currentClient = new TelegramBotClient(botToken);
            currentClient.StartReceiving();
            ConnectEvents();
            Console.ReadLine();
            currentClient.StopReceiving();
        }

        private static void ShowInfo()
        {
            currentClient.SendTextMessageAsync(chatId, "Привет, тут можно найти фильм на любой вкус. Этот бот поможет тебе выбрать что посмотреть. Рандомно или же по критериям и жанрам, приятного пользования))");
            currentClient.SendTextMessageAsync(chatId, "/ganres - чтобы выбрать фильм по жанру");

        }
        private static void ConnectEvents()
        {
            currentClient.OnMessage += BotOnMessage;
        }

        private async static void BotOnMessage(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if(message.Text != null)
            {
                ShowInfoAboutClient(message);
                switch (message.Text)
                {
                    case "/start":
                        SetChatId(message.Chat.Id);
                        ShowInfo();                 
                        break;
                    case "/ganres":
                        UI.ShowGanres(currentClient, chatId);
                        break;


                    default:                        
                            await currentClient.SendTextMessageAsync(message.Chat.Id, "Спасибо за собщение");
                        break;
                } 
            }
        }

       

        private static IReplyMarkup GetButtonsWithGanres()
        {
            return new ReplyKeyboardMarkup()
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                   
                }
            };
        }

        private static void SetChatId(long id)
        {
            chatId = id;
        }

        private static void ShowInfoAboutClient(Message _message)
        {
            Console.WriteLine("Имя клиента: " + _message.From.FirstName);
            Console.WriteLine("Ник клиента: " + _message.From.Username);
            Console.WriteLine("Текст сообщения: " + _message.Text);
            Console.WriteLine();
        }
    }
}
