using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public static class QueryExtensions
{
    [ExpressionMethod(nameof(TranslationHasLanguage))]
    public static bool HasLanguage(
        this Translation translation,
        long? languageToLearnId,
        long? languageToLearnFromId)
    {
        throw new InvalidOperationException();
    }
    
    public static IQueryable<Translation> HasLanguage(this IQueryable<Translation> queryable, long? languageToLearnId, long? languageToLearnFromId)
    {
        return queryable.Where(x => (languageToLearnId == null || x.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.Word.Translations.Any(t => t.LanguageId == languageToLearnFromId)));
    }
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this WordTopic translation,
        long? languageToLearnId,
        long? languageToLearnFromId)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<WordTopic, long?, long?, bool>> TopicHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.Word.Translations.Any(t => t.LanguageId == languageToLearnFromId));
    }
    
    public static Expression<Func<Translation, long?, long?, bool>> TranslationHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.LanguageId == languageToLearnFromId);
    }
    
    public static IQueryable<TranslationState> Learned(
        this IQueryable<TranslationState> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}