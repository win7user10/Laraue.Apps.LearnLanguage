using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Routing;

namespace Laraue.Apps.LearnLanguage.Services;

public static class RoutePathBuilderExtensions
{
    public static RoutePathBuilder AddTranslationParameters(
        this RoutePathBuilder builder,
        SelectedTranslation selectedTranslation)
    {
        return builder
            .WithQueryParameter(ParameterNames.LanguageToLearnFrom, selectedTranslation.LanguageIdToLearnFrom)
            .WithQueryParameter(ParameterNames.LanguageToLearn, selectedTranslation.LanguageIdToLearn);
    }
}