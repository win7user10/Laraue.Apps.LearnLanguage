using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public abstract record BaseSelectedTranslation
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? LanguageIdToLearn { get; init; }
    
    [FromQuery(ParameterNames.LanguageToLearnFrom)]
    public long? LanguageIdToLearnFrom { get; init; }

    public static implicit operator SelectedTranslation(BaseSelectedTranslation @this)
    {
        return new SelectedTranslation
        {
            LanguageIdToLearn = @this.LanguageIdToLearn,
            LanguageIdToLearnFrom = @this.LanguageIdToLearnFrom
        };
    }
}