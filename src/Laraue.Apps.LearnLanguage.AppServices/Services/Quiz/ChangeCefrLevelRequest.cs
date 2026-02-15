using Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public record ChangeCefrLevelRequest : WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.CefrLevelId)]
    public long CefrLevelId { get; init; }
}