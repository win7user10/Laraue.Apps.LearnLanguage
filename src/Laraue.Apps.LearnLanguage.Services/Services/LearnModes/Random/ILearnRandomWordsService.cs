using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public interface ILearnRandomWordsService
{
    Task SendRepeatingWindowAsync(WithSelectedTranslationRequest request, ReplyData replyData, CancellationToken ct = default);
    Task HandleSuggestedWordAsync(ReplyData replyData, HandleWordRequest request, CancellationToken ct = default);
    Task HandleRepeatingWindowWordsViewAsync(
        ReplyData replyData,
        DetailView request,
        CancellationToken ct = default);
}

public record HandleWordRequest : IWithTranslationIdentifierRequest
{
    public long SessionId { get; init; }
    public bool? IsRemembered { get; init; }
    public bool? ShowTranslation { get; init; }
    public long? WordId { get; init; }
    public long? MeaningId { get; init; }
    public long? TranslationId { get; init; }
}