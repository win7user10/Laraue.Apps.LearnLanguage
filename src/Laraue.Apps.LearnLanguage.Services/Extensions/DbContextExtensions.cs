using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Extensions;

public static class DbContextExtensions
{
    public static IQueryable<T> QueryGroupWordsWithStates<T>(
        this IQueryable<WordGroupWord> queryable,
        DatabaseContext dbContext,
        Expression<Func<WordGroupWord, WordTranslationState, T>> selector)
    {
        return queryable.LeftJoin(
            dbContext.WordTranslationStates.AsQueryable(),
            (wg, wts) =>
                wg.WordTranslationId == wts.WordTranslationId
                && wg.WordGroup.UserId == wts.UserId,
            selector);
    }
}