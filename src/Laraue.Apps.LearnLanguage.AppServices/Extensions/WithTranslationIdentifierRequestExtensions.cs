using System.Diagnostics.CodeAnalysis;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices.Extensions;

public static class WithTranslationIdentifierRequestExtensions
{
    public static bool TryGetTranslationIdentifier(
        this IWithTranslationIdentifierRequest request,
        [NotNullWhen(true)] out TranslationIdentifier? translationIdentifier)
    {
        if (request.WordId is not null && request.LanguageId is not null)
        {
            translationIdentifier = new TranslationIdentifier
            {
                WordId = request.WordId.Value,
                LanguageId = request.LanguageId.Value
            };

            return true;
        }

        translationIdentifier = null;
        return false;
    }
}