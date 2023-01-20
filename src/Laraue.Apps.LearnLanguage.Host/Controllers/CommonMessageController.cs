using Laraue.Apps.LearnLanguage.Commands;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;
using Laraue.Telegram.NET.Abstractions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class CommonMessageController : TelegramController
{
    private readonly IMediator _mediator;

    public CommonMessageController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [TelegramCallbackRoute(TelegramRoutes.DropMessage)]
    public Task DropLastMessageAsync(TelegramRequestContext requestContext)
    {
        return _mediator.Send(new DeleteLastMessageCommand
        {
            Data = requestContext.Update.CallbackQuery!,
            UserId = requestContext.UserId!,
        });
    }
}