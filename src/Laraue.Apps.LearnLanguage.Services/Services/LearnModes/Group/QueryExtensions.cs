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
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this MeaningTopic translation,
        long? languageToLearnId,
        long? languageToLearnFromId)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<MeaningTopic, long?, long?, bool>> TopicHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.Meaning.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.Meaning.Translations.Any(t => t.LanguageId == languageToLearnFromId));
    }
    
    public static Expression<Func<Translation, long?, long?, bool>> TranslationHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.Meaning.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.LanguageId == languageToLearnFromId);
    }
    
    public static IQueryable<TranslationState> Learned(
        this IQueryable<TranslationState> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}