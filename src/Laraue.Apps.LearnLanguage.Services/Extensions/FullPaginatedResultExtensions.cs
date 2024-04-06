using System.Diagnostics.CodeAnalysis;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Extensions;

public static class FullPaginatedResultExtensions
{
    public static bool TryGetOpenedWord(
        this IFullPaginatedResult<LearningItem> result,
        TranslationIdentifier? translationIdentifier,
        [NotNullWhen(true)] out LearningItem? learningItem)
    {
        if (translationIdentifier is null)
        {
            learningItem = null;
            return false;
        }

        learningItem = result.Data
            .FirstOrDefault(x => x.TranslationId == translationIdentifier);
        return learningItem is not null;
    }
}