using Laraue.Apps.LearnLanguage.Common;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public sealed class LearnListRequest
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? LanguageToLearnId { get; init; }
    
    [FromQuery(ParameterNames.LanguageToLearnFrom)]
    public long? LanguageToLearnFromId { get; init; }
}