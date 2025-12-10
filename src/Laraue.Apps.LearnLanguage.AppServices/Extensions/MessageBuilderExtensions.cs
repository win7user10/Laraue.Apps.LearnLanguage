using Laraue.Telegram.NET.Core.Utils;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.AppServices.Extensions;

public static class MessageBuilderExtensions
{
    public static InlineKeyboardButton MainMenuButton =>
        InlineKeyboardButton.WithCallbackData(Resources.Buttons.Menu, TelegramRoutes.Menu);
    
    public static TelegramMessageBuilder AddMainMenuButton(this TelegramMessageBuilder messageBuilder)
    {
        return messageBuilder.AddInlineKeyboardButtons([MainMenuButton]);
    }
    
    public static TelegramMessageBuilder AddBackMenuButton(this TelegramMessageBuilder messageBuilder, string callbackPath)
    {
        return messageBuilder.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(Resources.Buttons.Back, callbackPath)
        ]);
    }

    public static TelegramMessageBuilder AddDeleteMessageButton(
        this TelegramMessageBuilder messageBuilder,
        string text)
    {
        return messageBuilder.AddInlineKeyboardButtons([
            InlineKeyboardButton.WithCallbackData(text, TelegramRoutes.DropMessage)
        ]);
    }
}