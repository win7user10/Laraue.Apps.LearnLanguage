using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public record SelectQuizAnswerRequest
{
    [FromQuery(ParameterNames.QuestionId)]
    public long QuestionId { get; init; }
    
    [FromQuery(ParameterNames.AnswerWordId)]
    public long SelectedOptionId { get; init; }
}