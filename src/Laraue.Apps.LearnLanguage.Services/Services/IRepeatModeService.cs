using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IRepeatModeService
{
    Task SendRepeatingWindowAsync(ReplyData replyData, CancellationToken ct = default);
    Task HandleSuggestedWordAsync(ReplyData replyData, HandleWordRequest request, CancellationToken ct = default);
    Task HandleRepeatingWindowWordsViewAsync(
        ReplyData replyData,
        long sessionId,
        ChangeUserSettings request,
        int page,
        long? openedTranslationId,
        bool rememberState,
        CancellationToken ct = default);
}

public record HandleWordRequest(long SessionId, int TranslationId, bool? IsRemembered, bool? ShowTranslation);