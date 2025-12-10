using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;

public abstract record WithSelectedTranslationRequest
{
    [FromQuery(ParameterNames.LanguageToLearn)]
    public long? LanguageToLearnId { get; init; }

    public static implicit operator SelectedTranslation(WithSelectedTranslationRequest @this)
    {
        return new SelectedTranslation(@this.LanguageToLearnId);
    }
}