using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public static class QueryExtensions
{
    [ExpressionMethod(nameof(TranslationHasLanguage))]
    public static bool HasLanguage(
        this WordTranslation wordTranslation,
        SelectedTranslation selectedTranslation)
    {
        throw new InvalidOperationException();
    }
    
    [ExpressionMethod(nameof(TopicHasLanguage))]
    public static bool HasLanguage(
        this WordMeaningTopic wordTranslation,
        SelectedTranslation selectedTranslation)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<WordTranslation, SelectedTranslation, bool>> TranslationHasLanguage()
    {
        return (x, selectedTranslation)
            => (selectedTranslation.LanguageToLearnId == null ||
                x.WordMeaning.Word.LanguageId == selectedTranslation.LanguageToLearnId)
               && (selectedTranslation.LanguageToLearnFromId == null ||
                   x.LanguageId == selectedTranslation.LanguageToLearnFromId);
    }
    
    public static Expression<Func<WordMeaningTopic, SelectedTranslation, bool>> TopicHasLanguage()
    {
        return (x, selectedTranslation)
            => (selectedTranslation.LanguageToLearnId == null ||
                x.WordMeaning.Word.LanguageId == selectedTranslation.LanguageToLearnId)
               && (selectedTranslation.LanguageToLearnFromId == null ||
                   x.WordMeaning.Translations.Any(t => t.Id == selectedTranslation.LanguageToLearnFromId));
    }
    
    public static IQueryable<WordTranslationState> Learned(
        this IQueryable<WordTranslationState> wordTranslations)
    {
        return wordTranslations.Where(x => x.LearnedAt != null);
    }
}