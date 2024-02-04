using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class SettingsController(IUserSettingsService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.Settings)]
    public Task HandleSettingsRequestAsync(RequestContext request, CancellationToken ct)
    {
        return service.HandleSettingsViewAsync(ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.LanguageSettings)]
    public Task HandleLanguageSettingsRequestAsync(
        RequestContext context,
        [FromQuery] UpdateSettingsRequest request,
        CancellationToken ct)
    {
        return service.HandleLanguageSettingsViewAsync(ReplyData.FromRequest(context), request, ct);
    }
}