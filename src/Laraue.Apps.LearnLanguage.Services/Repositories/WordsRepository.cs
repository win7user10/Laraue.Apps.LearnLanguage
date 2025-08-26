using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

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