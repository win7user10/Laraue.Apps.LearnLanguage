using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class MenuController(IMenuService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.Menu)]
    public Task SendMenuAsync(RequestContext request, CancellationToken ct)
    {
        return service.SendMenuAsync(ReplyData.FromRequest(request), ct);
    }
}