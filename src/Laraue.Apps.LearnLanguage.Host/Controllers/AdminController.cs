using Laraue.Apps.LearnLanguage.AppServices;
using Laraue.Apps.LearnLanguage.AppServices.Services;
using Laraue.Telegram.NET.Authentication.Attributes;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class AdminController : TelegramController
{
    private readonly IStatsService _statsService;

    public AdminController(IStatsService statsService)
    {
        _statsService = statsService;
    }

    [TelegramMessageRoute("/admin")]
    [RequiresUserRole(Roles.Admin)]
    public Task SendAdminStatsAsync(RequestContext request, CancellationToken ct)
    {
        return _statsService.SendAdminStatsAsync(request.Update.GetUserId(), ct);
    }
}