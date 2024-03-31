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
    private readonly TimeSpan _learnAttemptTime = new(1, 0, 0);
    
    public Task ChangeWordLearnStateAsync(
        Guid userId,
        TranslationIdentifier translationId,
        bool? isLearned,
        bool? isMarked,
        CancellationToken ct = default)
    {
        if (!isLearned.HasValue && !isMarked.HasValue)
        {
            return Task.CompletedTask;
        }
        
        return context.TranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new TranslationState
                {
                    TranslationId = translationId.TranslationId,
                    MeaningId = translationId.MeaningId,
                    WordId = translationId.WordId,
                    UserId = userId,
                    LearnedAt = isLearned.GetValueOrDefault()
                        ? dateTimeProvider.UtcNow
                        : null,
                    IsMarked = isMarked.GetValueOrDefault(),
                    LearnAttempts = 1,
                }, x => new TranslationState
                {
                    LearnedAt = isLearned.HasValue
                        ? isLearned.Value
                            ? x.LearnedAt ?? dateTimeProvider.UtcNow
                            : null
                        : x.LearnedAt,
                    IsMarked = isMarked ?? x.IsMarked
                },
                () => new TranslationState
                {
                    UserId = userId,
                    TranslationId = translationId.TranslationId,
                    MeaningId = translationId.MeaningId,
                    WordId = translationId.WordId,
                },
                ct);
    }

    public Task IncrementLearnAttemptsIfRequiredAsync(Guid userId, TranslationIdentifier[] translationIds, CancellationToken ct = default)
    {
        if (translationIds.Length == 0)
        {
            return Task.CompletedTask;
        }
        
        var now = dateTimeProvider.UtcNow;
        
        return context.TranslationStates
            .ToLinqToDBTable()
            .Merge()
            .Using(translationIds
                .Select(id => new
                {
                    UserId = userId,
                    id.WordId,
                    id.MeaningId,
                    id.TranslationId,
                }))
            .On(
                x => new { x.UserId, x.WordId, x.MeaningId, x.TranslationId },
                x => new { x.UserId, x.WordId, x.MeaningId, x.TranslationId })
            .UpdateWhenMatched((o, n) => new TranslationState
            {
                LearnAttempts = o.LastOpenedAt - now >= _learnAttemptTime && o.LearnedAt == null
                    ? o.LearnAttempts + 1
                    : o.LearnAttempts,
                LastOpenedAt = o.LastOpenedAt - now >= _learnAttemptTime
                    ? now
                    : o.LastOpenedAt,
            })
            .InsertWhenNotMatched(e => new TranslationState
            {
                UserId = userId,
                LearnAttempts = 1,
                LastOpenedAt = dateTimeProvider.UtcNow,
                TranslationId = e.TranslationId,
                MeaningId = e.MeaningId,
                WordId = e.WordId
            })
            .MergeAsync(ct);
    }

    public Task<List<LearningLanguagePair>> GetAvailableLearningPairsAsync(CancellationToken ct = default)
    {
        return context.Translations
            .GroupBy(x => new
            {
                LanguageIdToLearn = x.Meaning.Word.LanguageId,
                LanguageCodeToLearn = x.Meaning.Word.Language.Name,
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