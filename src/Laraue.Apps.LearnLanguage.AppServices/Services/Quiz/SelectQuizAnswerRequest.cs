using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public record SelectQuizAnswerRequest
{
    [FromQuery(ParameterNames.OpenedWordId)]
    public long SelectedOptionId { get; init; }
}