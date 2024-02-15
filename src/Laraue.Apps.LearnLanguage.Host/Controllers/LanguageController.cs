using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LanguageController(ILearnRandomWordsService learnRandomWordsService) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.RepeatWindow)]
    public Task SendRepeatingWindowAsync(
        RequestContext context,
        [FromQuery] OpenModeRequest request,
        CancellationToken ct)
    {
        return learnRandomWordsService.SendRepeatingWindowAsync(request, ReplyData.FromRequest(context), ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.HandleSuggestion)]
    public Task HandleSuggestionAsync(RequestContext context, [FromQuery] HandleWordRequest request, CancellationToken ct)
    {
        return learnRandomWordsService.HandleSuggestedWordAsync(
            ReplyData.FromRequest(context),
            request,
            ct);
    }
    
    [TelegramCallbackRoute(TelegramRoutes.RepeatWindowWordsView)]
    public Task SendRepeatingWindowsWordsAsync(
        RequestContext context,
        [FromQuery] DetailView request,
        CancellationToken ct)
    {
        return learnRandomWordsService.HandleRepeatingWindowWordsViewAsync(
            ReplyData.FromRequest(context),
            request,
            ct);
    }
}