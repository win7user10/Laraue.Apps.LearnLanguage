using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;
using MediatR;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record SendWordGroupsCommand : BaseCommand<CallbackQuery>
{
    public int Page { get; init; }
}

public class SendWordGroupsCommandHandler : IRequestHandler<SendWordGroupsCommand, object?>
{
    private readonly IMediator _mediator;

    public SendWordGroupsCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<object?> Handle(SendWordGroupsCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            new GetGroupsQuery
            {
                Page = request.Page,
                PerPage = Constants.PaginationCount,
                UserId = request.UserId,
            },
            cancellationToken);
        
        await _mediator.Send(new RenderWordGroupsCommand(
            result,
            request.Data.Message.Chat.Id,
            request.Data.Message.MessageId,
            request.Data.Id),
            cancellationToken);

        await _mediator.Send(
            new UpdateLastViewedTranslationsCommand(
                Array.Empty<long>(), 
                request.UserId),
            cancellationToken);

        return null;
    }
}