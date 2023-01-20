using Laraue.Telegram.NET.Core.Extensions;
using MediatR;
using Telegram.Bot;
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
        await _telegramBotClient.DeleteMessageAsync(
            request.Data.GetUser().GetId(),
            request.Data.Message!.MessageId,
            cancellationToken);
        
        return null;
    }
}