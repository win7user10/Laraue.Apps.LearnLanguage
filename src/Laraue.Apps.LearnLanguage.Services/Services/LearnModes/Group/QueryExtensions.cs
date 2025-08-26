using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public static class QueryExtensions
{
    [ExpressionMethod(nameof(TranslationHasLanguage))]
    public static bool HasLanguage(
        this Translation translation,
        long? languageToLearnId)
    {
        throw new InvalidOperationException();
    }
    
    public static IQueryable<Translation> HasLanguage(this IQueryable<Translation> queryable, long? languageToLearnId)
    {
        return queryable.Where(x => (languageToLearnId == null || x.Word.Translations.Any(t => t.LanguageId == languageToLearnId)));
    }
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this WordTopic translation,
        long? languageToLearnId)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<WordTopic, long?, bool>> TopicHasLanguage()
    {
        return (x, languageToLearnId)
            => (languageToLearnId == null || x.Word.Translations.Any(t => t.LanguageId == languageToLearnId));
    }
    
    public static Expression<Func<Translation, long?, bool>> TranslationHasLanguage()
    {
        return (x, languageToLearnId)
            => (languageToLearnId == null || x.LanguageId == languageToLearnId);
    }
    
    public static IQueryable<LearnedTranslation> Learned(
        this IQueryable<LearnedTranslation> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}