using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

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
    [FromQuery(ParameterNames.SessionId)]
    public long SessionId { get; init; }
    
    [FromQuery(ParameterNames.LearnState)]
    public bool? IsRemembered { get; init; }
    
    [FromQuery(ParameterNames.ToggleTranslations)]
    public bool? ShowTranslation { get; init; }
    
    [FromQuery(ParameterNames.OpenedWordId)]
    public long? WordId { get; init; }
    
    [FromQuery(ParameterNames.OpenedMeaningId)]
    public long? MeaningId { get; init; }
    
    [FromQuery(ParameterNames.OpenedTranslationId)]
    public long? TranslationId { get; init; }
}