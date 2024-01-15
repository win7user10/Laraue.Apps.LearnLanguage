using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.Topic;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LearnByTopicController(ILearnByTopicService service) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.ListGroupsByTopic)]
    public Task HandleListRequestAsync(RequestContext request, CancellationToken ct)
    {
        return service.HandleListViewAsync(ReplyData.FromRequest(request), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.DetailGroupByTopic)]
    public Task HandleDetailRequestAsync(
        RequestContext context,
        [FromQuery] LearnByTopicRequest learnByGroupRequest,
        CancellationToken ct)
    {
        return service.HandleDetailViewAsync(
            ReplyData.FromRequest(context),
            learnByGroupRequest,
            ct);
    }
}