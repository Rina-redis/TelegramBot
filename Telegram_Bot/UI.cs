using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Telegram_Bot
{
    static class UI
    {
        public static void ShowGanres(TelegramBotClient currentClient, long chatId)
        {
            currentClient.SendTextMessageAsync(chatId, "/anime - аниме фильмы\n" +
                                                        "/boievik - боевики\n" +
                                                        "/biography - биографические\n" +
                                                        "/vestern - вестерн\n" +
                                                        "/military - военный\n"+
                                                        "/detective - детектив\n"+
                                                        "/detskie - детские\n"+
                                                        "/dokumentary - документальный\n"+
                                                        "/dramma - драмма\n"
                                                        );
        }
        public static void ShowInfoAboutClient(Message _message)
        {
            Console.WriteLine("Имя клиента: " + _message.From.FirstName);
            Console.WriteLine("Ник клиента: " + _message.From.Username);
            Console.WriteLine("Текст сообщения: " + _message.Text);
            Console.WriteLine();
        }
      
        public static void CreateDictionary()
        {
            Dictionary<string, string> commands = new Dictionary<string, string>();
            commands.Add("","");
        }
    }
}
