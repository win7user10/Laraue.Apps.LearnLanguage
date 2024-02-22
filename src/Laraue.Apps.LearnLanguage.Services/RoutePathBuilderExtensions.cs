using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Routing;

namespace Laraue.Apps.LearnLanguage.Services;

public static class RoutePathBuilderExtensions
{
    public static CallbackRoutePath AddTranslationParameters(
        this CallbackRoutePath routePath,
        SelectedTranslation selectedTranslation)
    {
        return routePath
            .WithQueryParameter(ParameterNames.LanguageToLearnFrom, selectedTranslation.LanguageToLearnFromId)
            .WithQueryParameter(ParameterNames.LanguageToLearn, selectedTranslation.LanguageToLearnId);
    }
}