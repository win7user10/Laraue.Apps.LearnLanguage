using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services;

/// <summary>
/// Handle quiz request
/// </summary>
public record QuizRequest : WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.OpenedWordId)]
    public long? SelectedOptionId { get; init; }
    
    [FromQuery(ParameterNames.FinishQuiz)]
    public bool FinishQuiz { get; init; }
    
    [FromQuery(ParameterNames.StartQuiz)]
    public bool StartQuiz { get; init; }
}