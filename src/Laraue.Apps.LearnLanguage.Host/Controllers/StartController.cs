using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class StartController : TelegramController
{
    private readonly IStatsService _statsService;

    public StartController(IStatsService statsService)
    {
        _statsService = statsService;
    }
    
    [TelegramMessageRoute(TelegramRoutes.Start)]
    public Task StartAsync(RequestContext request)
    {
        return _statsService.SendStartAsync(
            request.UserId,
            request.Update.GetUserId());
    }
}