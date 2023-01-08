using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Commands;

public static class MessageBuilderExtensions
{
    public static TelegramMessageBuilder AddMainMenuButton(this TelegramMessageBuilder messageBuilder)
    {
        return messageBuilder.AddInlineKeyboardButtons(new []
        {
            InlineKeyboardButton.WithCallbackData("Menu", TelegramRoutes.Menu)
        });
    }
}