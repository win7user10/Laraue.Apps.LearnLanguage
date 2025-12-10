using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Contracts;
using Laraue.Telegram.NET.Core.Routing;

namespace Laraue.Apps.LearnLanguage.AppServices;

public static class RoutePathBuilderExtensions
{
    public static CallbackRoutePath WithTranslationDirection(
        this CallbackRoutePath routePath,
        SelectedTranslation selectedTranslation)
    {
        return routePath
            .WithQueryParameter(ParameterNames.LanguageToLearn, selectedTranslation.LanguageToLearnId);
    }
    
    public static CallbackRoutePath WithTranslationIdentifier(
        this CallbackRoutePath routePath,
        TranslationIdentifier translationIdentifier)
    {
        return routePath
            .WithQueryParameter(ParameterNames.OpenedWordId, translationIdentifier.WordId)
            .WithQueryParameter(ParameterNames.OpenedLanguageId, translationIdentifier.LanguageId);
    }
}