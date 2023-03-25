using Laraue.Apps.LearnLanguage.Commands;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StartController : TelegramController
{
    private readonly IMediator _mediator;

    public StartController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [TelegramMessageRoute(TelegramRoutes.Start)]
    public Task StartAsync(RequestContext requestContext)
    {
        return _mediator.Send(new SendStartMessageCommand
        {
            Data = requestContext.Update.Message!,
            UserId = requestContext.UserId!,
        });
    }
}