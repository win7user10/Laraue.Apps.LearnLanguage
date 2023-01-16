using Laraue.Telegram.NET.Core.Utils;
using Laraue.Telegram.NET.MediatR;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;

public record RenderMenuCommand(Unit Data, long ChatId, int MessageId, string CallbackQueryId)
    : BaseEditMessageCommand<Unit>(Data, ChatId, MessageId, CallbackQueryId);

public class RenderMenuCommandHandler : BaseEditMessageCommandHandler<RenderMenuCommand, Unit>
{
    public RenderMenuCommandHandler(ITelegramBotClient client) : base(client)
    {
    }

    protected override void HandleInternal(RenderMenuCommand request, TelegramMessageBuilder telegramMessageBuilder)
    {
        telegramMessageBuilder.AppendRow("Please select the action");
        
        telegramMessageBuilder.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData("Learn words", TelegramRoutes.Groups)
        });
        
        telegramMessageBuilder.AddInlineKeyboardButtons(new[]
        {
            InlineKeyboardButton.WithCallbackData("See stat", TelegramRoutes.Stat)
        });
    }
}