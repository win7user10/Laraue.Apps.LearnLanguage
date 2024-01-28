namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public interface ILearnRandomWordsService
{
    Task SendRepeatingWindowAsync(ReplyData replyData, CancellationToken ct = default);
    Task HandleSuggestedWordAsync(ReplyData replyData, HandleWordRequest request, CancellationToken ct = default);
    Task HandleRepeatingWindowWordsViewAsync(
        ReplyData replyData,
        LearnRequest request,
        CancellationToken ct = default);
}

public record HandleWordRequest(long SessionId, int TranslationId, bool? IsRemembered, bool? ShowTranslation);