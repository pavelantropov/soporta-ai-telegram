using SoportaAI.Telegram.Infrastructure.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;

Console.WriteLine("Запущен бот " + BotService.Bot.GetMeAsync().Result.FirstName);

var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOptions = new ReceiverOptions
{
	AllowedUpdates = { }, // receive all update types
};
BotService.Bot.StartReceiving(
	BotService.HandleUpdateAsync,
	BotService.HandleErrorAsync,
	receiverOptions,
	cancellationToken
);
Console.ReadLine();