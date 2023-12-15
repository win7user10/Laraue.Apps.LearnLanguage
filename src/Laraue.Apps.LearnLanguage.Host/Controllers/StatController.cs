using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StatController : TelegramController
{
    private readonly IStatsService _statsService;

    public StatController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [TelegramCallbackRoute(TelegramRoutes.Stat)]
    public Task SendStatsAsync(RequestContext request, CancellationToken ct)
    {
        return _statsService.SendStatsAsync(ReplyData.FromRequest(request), ct);
    }
}