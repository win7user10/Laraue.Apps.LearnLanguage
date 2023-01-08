using Laraue.Telegram.NET.Core.Utils;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;

public record RenderViewCommand<TData>(TData Data, long ChatId, int MessageId, string CallbackQueryId)
    : IRequest;

public abstract class RenderViewCommandHandler<TCommand, TData> : IRequestHandler<TCommand>
    where TCommand : RenderViewCommand<TData>
{
    private readonly ITelegramBotClient _client;

    protected RenderViewCommandHandler(ITelegramBotClient client)
    {
        _client = client;
    }

    public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var messageBuilder = new TelegramMessageBuilder();
        
        HandleInternal(request, messageBuilder);

        try
        {
            await _client.EditMessageTextAsync(
                request.ChatId,
                request.MessageId,
                messageBuilder.Text,
                ParseMode.Html,
                replyMarkup: messageBuilder.InlineKeyboard,
                cancellationToken: cancellationToken);
        }
        catch (ApiRequestException)
        {
            // Source does not modified.
        }

        await _client.AnswerCallbackQueryAsync(
            request.CallbackQueryId,
            cancellationToken: cancellationToken);
        
        return Unit.Value;
    }
    
    protected abstract void HandleInternal(TCommand request, TelegramMessageBuilder telegramMessageBuilder);
}