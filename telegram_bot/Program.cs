
using Telegram.Bot;
using Telegram.Bot.Types;
using telegram_bot.TelegramBotFolder;

namespace telegram_bot
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {

            const string token = "6843753914:AAGsyVIyyhWGrsW9wgoiT4mGAtVCj1n_p9E";
            TelegramBotHandler handler = new TelegramBotHandler(token);
            try
            {
                 await handler.BotHandle();
            }
            catch (Exception ex)
            {
                throw new Exception("BLOKLANMAYDI");
                
                };
            }
        }
    }

