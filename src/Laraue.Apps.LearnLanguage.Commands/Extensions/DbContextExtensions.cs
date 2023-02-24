using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.Commands.Extensions;

public static class DbContextExtensions
{
    public static IQueryable<T> QueryGroupWordsWithStates<T>(
        this IQueryable<WordGroupWord> queryable,
        DatabaseContext dbContext,
        Expression<Func<WordGroupWord, WordTranslationState, T>> selector)
    {
        return queryable.Join(
            dbContext.WordTranslationStates,
            wg => new { wg.WordTranslationId, wg.WordGroup.UserId },
            wts => new { wts.WordTranslationId, wts.UserId },
            selector);
    }
}