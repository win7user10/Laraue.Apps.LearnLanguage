using Laraue.Apps.LearnLanguage.Commands;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Telegram.NET.Authentication.Services;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class MenuController : TelegramController
{
    private readonly IMediator _mediator;

    public MenuController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Menu)]
    public Task SendMenuAsync(RequestContext requestContext)
    {
        return _mediator.Send(new SendMenuCommand
        {
            Data = requestContext.Update.CallbackQuery!,
            UserId = requestContext.UserId!,
        });
    }
}