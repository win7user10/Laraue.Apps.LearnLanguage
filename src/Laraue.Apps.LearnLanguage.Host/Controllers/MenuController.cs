using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class MenuController : TelegramController
{
    private readonly IStatsService _statsService;

    public MenuController(IStatsService statsService)
    {
        _statsService = statsService;
    }
    
    [TelegramCallbackRoute(TelegramRoutes.Menu)]
    public Task SendMenuAsync(RequestContext request, CancellationToken ct)
    {
        return _statsService.SendMenuAsync(ReplyData.FromRequest(request), ct);
    }
}