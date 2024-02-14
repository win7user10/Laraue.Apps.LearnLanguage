using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public static class QueryExtensions
{
    [ExpressionMethod(nameof(TranslationHasLanguage))]
    public static bool HasLanguage(
        this WordTranslation wordTranslation,
        long languageIdToLearn,
        long languageIdToLearnFrom)
    {
        throw new InvalidOperationException();
    }
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this WordMeaningTopic wordTranslation,
        long languageIdToLearn,
        long languageIdToLearnFrom)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<WordTranslation, long, long, bool>> TranslationHasLanguage()
    {
        return (x, languageIdToLearn, languageIdToLearnFrom) 
            => x.WordMeaning.Word.LanguageId == languageIdToLearn && x.LanguageId == languageIdToLearnFrom;
    }
    
    public static Expression<Func<WordMeaningTopic, long, long, bool>> TopicHasLanguage()
    {
        return (x, languageIdToLearn, languageIdToLearnFrom)
            => x.WordMeaning.Word.LanguageId == languageIdToLearn &&
               x.WordMeaning.Translations.Any(t => t.Id == languageIdToLearnFrom);
    }
    
    public static IQueryable<WordTranslationState> Learned(
        this IQueryable<WordTranslationState> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}