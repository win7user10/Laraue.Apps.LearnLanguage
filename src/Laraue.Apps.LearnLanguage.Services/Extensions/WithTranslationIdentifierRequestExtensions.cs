using System.Diagnostics.CodeAnalysis;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Extensions;

public static class WithTranslationIdentifierRequestExtensions
{
    public static bool TryGetTranslationIdentifier(
        this IWithTranslationIdentifierRequest request,
        [NotNullWhen(true)] out TranslationIdentifier? translationIdentifier)
    {
        if (request.WordId is not null && request.MeaningId is not null && request.TranslationId is not null)
        {
            translationIdentifier = new TranslationIdentifier
            {
                WordId = request.WordId.Value,
                TranslationId = request.TranslationId.Value
            };

            return true;
        }

        translationIdentifier = null;
        return false;
    }
}