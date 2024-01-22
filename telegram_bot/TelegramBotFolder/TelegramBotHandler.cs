using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace telegram_bot.TelegramBotFolder
{
    public class TelegramBotHandler
    {
        public string Token { get; set; }
        public TelegramBotHandler(string token)
        {
            this.Token = token;
        }



        public async Task BotHandle()
        {
            var botClient = new TelegramBotClient($"{this.Token}");

            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();


        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message is not { } message)
                return;
            var chatId = message.Chat.Id;


            if (message.Type != MessageType.Text)
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Iltimos link yuboring",
                    cancellationToken: cancellationToken);
            else
            {
                try
                {
                    string data = message.Text!.Replace("www.", "dd");
                    await Console.Out.WriteLineAsync(data);
                    await botClient.SendVideoAsync(
                        chatId: chatId,
                        video: InputFile.FromUri($"{data}"),
                        cancellationToken: cancellationToken);
                }
                catch
                {
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Notogri link",
                        cancellationToken: cancellationToken);
                }
            }


            Console.WriteLine($"Received a '{message.Text}' message in chat {chatId}.");
        }




        
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}

