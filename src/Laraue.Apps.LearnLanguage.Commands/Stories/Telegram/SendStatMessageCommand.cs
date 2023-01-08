using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;
using MediatR;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record SendStatMessageCommand : BaseCommand<CallbackQuery>;

public class SendStatMessageCommandHandler : IRequestHandler<SendStatMessageCommand, object?>
{
    private readonly IMediator _mediator;

    public SendStatMessageCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<object?> Handle(SendStatMessageCommand request, CancellationToken cancellationToken)
    {
        var data = await _mediator.Send(
            new GetLearnStateQuery(request.UserId),
             cancellationToken);

        await _mediator.Send(new RenderStatViewCommand(data,
            request.Data.Message.Chat.Id,
            request.Data.Message.MessageId,
            request.Data.Id),
            cancellationToken);

        return null;
    }
}