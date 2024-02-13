using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.CefrLevel;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LearnByCefrLevelController(ILearnByCefrLevelService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.ListGroupsByCefrLevel)]
    public Task HandleListRequestAsync(
        RequestContext request,
        [FromQuery] LearnListRequest learnListRequest,
        CancellationToken ct)
    {
        return service.HandleListViewAsync(learnListRequest, ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.DetailGroupByCefrLevel)]
    public Task HandleDetailRequestAsync(
        RequestContext context,
        [FromQuery] LearnByCefrLevelRequest learnByGroupRequest,
        CancellationToken ct)
    {
        return service.HandleDetailViewAsync(
            ReplyData.FromRequest(context),
            learnByGroupRequest,
            ct);
    }
}