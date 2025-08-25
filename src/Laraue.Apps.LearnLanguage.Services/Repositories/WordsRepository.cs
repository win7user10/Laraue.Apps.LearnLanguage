using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class WordsRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    : IWordsRepository
{
    public Task<List<LearningLanguagePair>> GetAvailableLearningPairsAsync(CancellationToken ct = default)
    {
        return context.Translations
            .GroupBy(x => new
            {
                LanguageIdToLearn = x.Word.LanguageId,
                LanguageCodeToLearn = x.Word.Language.Name,
                LanguageIdToLearnFrom = x.LanguageId,
                LanguageCodeToLearnFrom = x.Language.Name,
            })
            .Select(x => new LearningLanguagePair(
                new LearningLanguagePairItem(x.Key.LanguageIdToLearn, x.Key.LanguageCodeToLearn),
                new LearningLanguagePairItem(x.Key.LanguageIdToLearnFrom, x.Key.LanguageCodeToLearnFrom),
                x.Count()))
            .ToListAsyncLinqToDB(ct);
    }
}