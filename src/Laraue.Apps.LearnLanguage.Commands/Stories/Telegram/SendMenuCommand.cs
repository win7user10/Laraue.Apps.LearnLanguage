using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;
using MediatR;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record SendMenuCommand : BaseCommand<CallbackQuery>;

public class SendMenuCommandHandler : IRequestHandler<SendMenuCommand, object?>
{
    private readonly IMediator _mediator;

    public SendMenuCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<object?> Handle(SendMenuCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new RenderMenuCommand(Unit.Value, 
            request.Data.Message.Chat.Id,
            request.Data.Message.MessageId,
            request.Data.Id),
            cancellationToken);
        
        return null;
    }
}