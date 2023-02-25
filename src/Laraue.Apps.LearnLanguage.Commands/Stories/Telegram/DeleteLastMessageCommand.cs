using Laraue.Telegram.NET.Core.Extensions;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record DeleteLastMessageCommand : BaseCommand<CallbackQuery>;

public class DeleteLastMessageCommandHandler : IRequestHandler<DeleteLastMessageCommand, object?>
{
    private readonly ITelegramBotClient _telegramBotClient;

    public DeleteLastMessageCommandHandler(ITelegramBotClient telegramBotClient)
    {
        _telegramBotClient = telegramBotClient;
    }

    public async Task<object?> Handle(DeleteLastMessageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _telegramBotClient.DeleteMessageAsync(
                request.Data.GetUser().GetId(),
                request.Data.Message!.MessageId,
                cancellationToken);
            
            await _telegramBotClient.AnswerCallbackQueryAsync(
                request.Data.Id,
                cancellationToken: cancellationToken);
        }
        catch (ApiRequestException)
        {
        }
        
        return null;
    }
}