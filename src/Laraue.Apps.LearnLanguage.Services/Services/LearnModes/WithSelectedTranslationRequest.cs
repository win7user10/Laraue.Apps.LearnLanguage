using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public abstract record WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? LanguageIdToLearn { get; init; }
    
    [FromQuery(ParameterNames.LanguageToLearnFrom)]
    public long? LanguageIdToLearnFrom { get; init; }

    public static implicit operator SelectedTranslation(WithSelectedTranslationRequest @this)
    {
        return new SelectedTranslation
        {
            LanguageToLearnId = @this.LanguageIdToLearn,
            LanguageToLearnFromId = @this.LanguageIdToLearnFrom
        };
    }
}