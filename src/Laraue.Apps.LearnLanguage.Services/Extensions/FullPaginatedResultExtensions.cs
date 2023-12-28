using System.Diagnostics.CodeAnalysis;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Extensions;

public static class FullPaginatedResultExtensions
{
    public static bool TryGetOpenedWord(
        this IFullPaginatedResult<LearningItem> result,
        long? openedTranslationId,
        [NotNullWhen(true)] out LearningItem? learningItem)
    {
        learningItem = result.Data
            .FirstOrDefault(x => x.TranslationId == openedTranslationId);
        return learningItem is not null;
    }
}