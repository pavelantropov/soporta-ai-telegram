using Telegram.Bot;
using Telegram.Bot.Types;

namespace SoportaAI.Telegram.Infrastructure.Services;

public class BotService : IBotService
{
	public static readonly ITelegramBotClient Bot = new TelegramBotClient("6033154330:AAEIklCXObh95lbI7y9_E_gt89S8nUFec-Y");

	public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
	{
		// Некоторые действия
		Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
		if (update.Type == global::Telegram.Bot.Types.Enums.UpdateType.Message)
		{
			var message = update.Message;

			if (message == null) return; //!!!

			if (string.Equals(message.Text, @"/start", StringComparison.InvariantCultureIgnoreCase))
			{
				await botClient.SendTextMessageAsync(message.Chat, "Здравствуйте! Я SoportaAI, ваш ассистент и собеседник.", cancellationToken: cancellationToken);
				return;
			}

			await botClient.SendTextMessageAsync(message.Chat, "Я пока не умею отвечать на сообщения, но скоро научусь!", cancellationToken: cancellationToken);
		}
	}

	public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
	{
		// Некоторые действия
		Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
	}
}