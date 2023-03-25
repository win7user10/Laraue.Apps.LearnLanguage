using Laraue.Apps.LearnLanguage.Commands.Stories;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Jobs;

public class CalculateDailyStatJob
{
    private readonly IMediator _mediator;

    public CalculateDailyStatJob(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task ExecuteAsync()
    {
        return _mediator.Send(new SendDailyStatMessageCommand());
    }
}