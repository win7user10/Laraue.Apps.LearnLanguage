using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public static class QueryExtensions
{
    [ExpressionMethod(nameof(TranslationHasLanguage))]
    public static bool HasLanguage(
        this WordTranslation wordTranslation,
        long? languageToLearnId,
        long? languageToLearnFromId)
    {
        throw new InvalidOperationException();
    }
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this WordMeaningTopic wordTranslation,
        long? languageToLearnId,
        long? languageToLearnFromId)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<WordMeaningTopic, long?, long?, bool>> TopicHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.WordMeaning.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.WordMeaning.Translations.Any(t => t.LanguageId == languageToLearnFromId));
    }
    
    public static Expression<Func<WordTranslation, long?, long?, bool>> TranslationHasLanguage()
    {
        return (x, languageToLearnId, languageToLearnFromId)
            => (languageToLearnId == null || x.WordMeaning.Word.LanguageId == languageToLearnId)
               && (languageToLearnFromId == null || x.LanguageId == languageToLearnFromId);
    }
    
    public static IQueryable<WordTranslationState> Learned(
        this IQueryable<WordTranslationState> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}