using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Routing.Attributes;

namespace Laraue.Apps.LearnLanguage.Host.Controllers;

public class LanguageController(ILearnRandomWordsService learnRandomWordsService) : TelegramController
{
    [TelegramCallbackRoute(TelegramRoutes.RepeatWindow)]
    public Task SendRepeatingWindowAsync(RequestContext request, CancellationToken ct)
    {
        return learnRandomWordsService.SendRepeatingWindowAsync(ReplyData.FromRequest(request), ct);
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
        [FromQuery] ChangeUserSettings request,
        [FromQuery(ParameterNames.Page)] int page,
        [FromQuery(ParameterNames.SessionId)] long sessionId,
        [FromQuery(ParameterNames.OpenedTranslationId)] long? openedTranslationId,
        [FromQuery(ParameterNames.RememberState)] bool rememberState,
        CancellationToken ct)
    {
        return learnRandomWordsService.HandleRepeatingWindowWordsViewAsync(
            ReplyData.FromRequest(context),
            sessionId,
            request,
            page,
            openedTranslationId,
            rememberState,
            ct);
    }
}