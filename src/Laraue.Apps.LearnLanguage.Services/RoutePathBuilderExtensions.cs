using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Routing;

namespace Laraue.Apps.LearnLanguage.Services;

public static class RoutePathBuilderExtensions
{
    public static CallbackRoutePath WithTranslationDirection(
        this CallbackRoutePath routePath,
        SelectedTranslation selectedTranslation)
    {
        return routePath
            .WithQueryParameter(ParameterNames.LanguageToLearnFrom, selectedTranslation.LanguageToLearnFromId)
            .WithQueryParameter(ParameterNames.LanguageToLearn, selectedTranslation.LanguageToLearnId);
    }
    
    public static CallbackRoutePath WithTranslationIdentifier(
        this CallbackRoutePath routePath,
        TranslationIdentifier translationIdentifier)
    {
        return routePath
            .WithQueryParameter(ParameterNames.OpenedWordId, translationIdentifier.WordId)
            .WithQueryParameter(ParameterNames.OpenedMeaningId, translationIdentifier.MeaningId)
            .WithQueryParameter(ParameterNames.OpenedTranslationId, translationIdentifier.TranslationId);
    }
}