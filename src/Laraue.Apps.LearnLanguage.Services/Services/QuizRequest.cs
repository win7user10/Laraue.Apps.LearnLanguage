using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services;

/// <summary>
/// Handle quiz request
/// </summary>
public record QuizRequest : WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.OpenedWordId)]
    public long? SelectedOptionId { get; init; }
    
    [FromQuery(ParameterNames.FinishQuiz)]
    public bool FinishQuiz { get; init; }
}