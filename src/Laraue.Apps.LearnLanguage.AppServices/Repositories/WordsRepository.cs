using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories;

public class WordsRepository(DatabaseContext context)
    : IWordsRepository
{
    public Task<List<LearningLanguagePair>> GetAvailableLearningPairsAsync(CancellationToken ct = default)
    {
        return context.Translations
            .GroupBy(x => new
            {
                LanguageIdToLearn = x.LanguageId,
                LanguageCodeToLearn = x.Language.Name,
            })
            .Select(x => new LearningLanguagePair(
                new LearningLanguagePairItem(x.Key.LanguageIdToLearn, x.Key.LanguageCodeToLearn),
                x.Count()))
            .ToListAsyncLinqToDB(ct);
    }
}