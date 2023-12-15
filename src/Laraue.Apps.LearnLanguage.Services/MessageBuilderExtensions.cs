using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Services;

public static class MessageBuilderExtensions
{
    public static TelegramMessageBuilder AddMainMenuButton(this TelegramMessageBuilder messageBuilder)
    {
        return messageBuilder.AddInlineKeyboardButtons(new []
        {
            InlineKeyboardButton.WithCallbackData("Menu", TelegramRoutes.Menu)
        });
    }

    public static TelegramMessageBuilder AddDeleteMessageButton(
        this TelegramMessageBuilder messageBuilder,
        string text)
    {
        return messageBuilder.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData(text, TelegramRoutes.DropMessage)
        });
    }
}