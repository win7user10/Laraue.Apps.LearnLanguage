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
    
    [FromQuery(ParameterNames.ActionId)]
    public RequestAction? RequestAction { get; init; }
    
    [FromQuery(ParameterNames.TopicId)]
    public long? TopicId { get; init; }
}

public enum RequestAction
{
    StartQuiz,
    FinishQuiz,
    SelectTopic,
}