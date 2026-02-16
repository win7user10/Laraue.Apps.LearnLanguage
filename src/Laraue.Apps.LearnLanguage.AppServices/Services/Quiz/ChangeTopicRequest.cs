using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public record ChangeTopicRequest : WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.TopicId)]
    public long TopicId { get; init; }

    [FromQuery(ParameterNames.Enable)]
    public bool Enable { get; init; }
}