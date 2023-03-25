using Laraue.Apps.LearnLanguage.Commands;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StatController : TelegramController
{
    private readonly IMediator _mediator;

    public StatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [TelegramCallbackRoute(TelegramRoutes.Stat)]
    public Task SendStatAsync(RequestContext requestContext)
    {
        return _mediator.Send(new SendStatMessageCommand
        {
            Data = requestContext.Update.CallbackQuery!,
            UserId = requestContext.UserId!,
        });
    }
}