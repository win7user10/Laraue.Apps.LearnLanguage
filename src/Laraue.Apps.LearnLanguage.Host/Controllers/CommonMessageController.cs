using Laraue.Apps.LearnLanguage.Services;
using Laraue.Telegram.NET.Core.Extensions;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;
using Telegram.Bot;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class CommonMessageController : TelegramController
{
    private readonly ITelegramBotClient _client;

    public CommonMessageController(ITelegramBotClient client)
    {
        _client = client;
    }

    [TelegramCallbackRoute(TelegramRoutes.DropMessage)]
    public Task DropLastMessageAsync(RequestContext request, CancellationToken ct)
    {
        return _client.DeleteMessageAsync(
            request.Update.GetUserId(),
            request.Update.Message!.MessageId,
            ct);
    }
}