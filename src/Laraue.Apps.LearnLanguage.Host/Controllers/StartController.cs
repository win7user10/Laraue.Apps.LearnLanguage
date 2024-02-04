using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StartController(IMenuService service) : TelegramController
{
    [TelegramMessageRoute(TelegramRoutes.Start)]
    public Task StartAsync(RequestContext request)
    {
        return service.SendStartAsync(
            request.UserId,
            request.Update.GetUserId());
    }
}