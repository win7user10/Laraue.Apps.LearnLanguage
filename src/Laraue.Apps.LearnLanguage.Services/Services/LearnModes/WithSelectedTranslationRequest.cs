using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public abstract record WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? LanguageToLearnId { get; init; }
    
    [FromQuery(ParameterNames.LanguageToLearnFrom)]
    public long? LanguageToLearnFromId { get; init; }

    public static implicit operator SelectedTranslation(WithSelectedTranslationRequest @this)
    {
        return new SelectedTranslation(@this.LanguageToLearnId, @this.LanguageToLearnFromId);
    }
}