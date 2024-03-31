using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public class LearnRandomWordsRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    : ILearnRandomWordsRepository
{
    public Task<RepeatSessionState?> GetRepeatSessionStateAsync(Guid userId, CancellationToken ct = default)
    {
        return context.RepeatSessions
            .Where(x => x.UserId == userId)
            .Where(x => x.State != RepeatState.Finished)
            .Select(x => new RepeatSessionState(x.Id, x.State))
            .FirstOrDefaultAsyncEF(ct);
    }

    public async Task<NextRepeatWordTranslation?> GetNextRepeatWordAsync(
        long sessionId,
        NextWordPreference wordPreference,
        CancellationToken ct = default)
    {
        var sessionInfo = await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => new { x.UserId, x.LanguageToLearnId, x.LanguageToLearnFromId })
            .FirstAsyncLinqToDB(ct);
        
        var query = context.Translations
            .Where(t => t.HasLanguage(sessionInfo.LanguageToLearnId, sessionInfo.LanguageToLearnFromId))
            .Where(x => !context.RepeatSessionTranslations
                .Where(y => y.RepeatSessionId == sessionId)
                .Select(y => y.TranslationId)
                .Contains(x.Id))
            .LeftJoin(
                context.TranslationStates.AsQueryable(),
                (wt, wts) => wt.Id == wts!.TranslationId && wts.UserId == sessionInfo.UserId,
                (t, ts) => new { t, ts })
            .OrderBy(x => x.ts.LearnedAt.HasValue)
            .ThenByDescending(x => x.ts.RepeatedAt);

        switch (wordPreference)
        {
            case NextWordPreference.MostSeen:
                query = query.ThenByDescending(x => x.ts.LearnAttempts);
                break;
            case NextWordPreference.LeastSeen:
                query = query.ThenBy(x => x.ts.LearnAttempts);
                break;
            case NextWordPreference.Random:
                query = query.ThenBy(_ => Linq2db.NewGuid());
                break;
        }

        return await query
            .Select(x => new NextRepeatWordTranslation(
                new TranslationIdentifier
                {
                    TranslationId = x.t.Id,
                    MeaningId = x.t.MeaningId,
                    WordId = x.t.WordId
                },
                x.t.Meaning.Word.Text,
                x.t.Text,
                x.ts.LearnedAt,
                x.ts.RepeatedAt,
                x.ts.LearnAttempts,
                x.t.Meaning.CefrLevel!.Name,
                x.t.Meaning.Topics.Select(t => t.Topic.Name).ToArray(),
                x.t.Difficulty))
            .FirstOrDefaultAsyncLinqToDB(ct);
    }

    public Task<NextRepeatWordTranslation> GetRepeatWordAsync(
        Guid userId,
        TranslationIdentifier translationIdentifier,
        CancellationToken ct = default)
    {
        return context.Translations
            .Where(x => x.WordId == translationIdentifier.WordId)
            .Where(x => x.MeaningId == translationIdentifier.MeaningId)
            .Where(x => x.Id == translationIdentifier.TranslationId)
            .LeftJoin(
                context.TranslationStates.AsQueryable(),
                (wt, wts) => wt.Id == wts!.TranslationId && wts.UserId == userId,
                (t, ts) => new { t, ts })
            .Select(x => new NextRepeatWordTranslation(
                new TranslationIdentifier
                {
                    TranslationId = x.t.Id,
                    MeaningId = x.t.MeaningId,
                    WordId = x.t.WordId
                },
                x.t.Meaning.Word.Text,
                x.t.Text,
                x.ts.LearnedAt,
                x.ts.RepeatedAt,
                x.ts.LearnAttempts,
                x.t.Meaning.CefrLevel!.Name,
                x.t.Meaning.Topics.Select(t => t.Topic.Name).ToArray(),
                x.t.Difficulty))
            .FirstAsyncLinqToDB(ct);
    }

    public Task<RepeatSessionInfo> GetSessionInfoAsync(long sessionId, CancellationToken ct = default)
    {
        return context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => new RepeatSessionInfo(
                x.Words.Count(
                    y => y.RepeatSessionWordState != RepeatSessionWordState.RepeatedSinceFirstAttempt),
                x.Words.Count(
                    y => y.RepeatSessionWordState == RepeatSessionWordState.RepeatedSinceFirstAttempt),
                context.Translations
                    .Where(t => x.Words.All(w =>
                        w.TranslationId != t.Id || w.RepeatSessionWordState != RepeatSessionWordState.RepeatedSinceFirstAttempt))
                    .Count(t => t.HasLanguage(x.LanguageToLearnId, x.LanguageToLearnFromId)),
                x.StartedAt,
                x.FinishedAt))
            .FirstAsyncLinqToDB(ct);
    }

    public async Task<long> CreateSessionAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var session = new RepeatSession
        {
            UserId = userId,
            LanguageToLearnFromId = selectedTranslation.LanguageToLearnFromId,
            LanguageToLearnId = selectedTranslation.LanguageToLearnId,
        };

        context.RepeatSessions.Add(session);
        await context.SaveChangesAsync(ct);

        return session.Id;
    }

    public async Task<RepeatState> AddWordToSessionAsync(
        long sessionId,
        TranslationIdentifier translationIdentifier,
        bool isRemembered,
        CancellationToken ct = default)
    {
        await using var t = await context.Database.BeginTransactionAsync(ct);
        
        var info = await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => new
            {
                x.State,
                x.UserId,
                WordsCount = x.Words.Count(y => y.RepeatSessionWordState == RepeatSessionWordState.NotRepeated),
                AlreadyAdded = x.Words.Any(y =>
                    y.TranslationId == translationIdentifier.TranslationId
                    && y.Translation.MeaningId == translationIdentifier.MeaningId
                    && y.Translation.WordId == translationIdentifier.WordId)
            })
            .FirstAsyncEF(ct);

        // If repeat session doesn't allow to add new word return the previous session state.
        if (info.State != RepeatState.Filling
            || info.WordsCount >= Constants.RepeatModeGroupSize
            || info.AlreadyAdded)
        {
            return info.State;
        }
        
        var word = new RepeatSessionTranslation
        {
            TranslationId = translationIdentifier.TranslationId,
            MeaningId = translationIdentifier.MeaningId,
            WordId = translationIdentifier.WordId,
            RepeatSessionId = sessionId,
            RepeatSessionWordState = isRemembered
                ? RepeatSessionWordState.RepeatedSinceFirstAttempt
                : RepeatSessionWordState.NotRepeated
        };

        context.Add(word);
        await context.SaveChangesAsync(ct);

        if (isRemembered)
        {
            await UpsertTranslationStateWithRepeatedStateAsync(info.UserId, translationIdentifier, ct);
        }

        // If word to remember has been added to the session, session words count increments.
        // When the words count reach required amount of elements it changes the state.
        var newAddedWordsCount = isRemembered ? info.WordsCount : info.WordsCount + 1;
        if (newAddedWordsCount != Constants.RepeatModeGroupSize)
        {
            await t.CommitAsync(ct);
            return info.State;
        }

        await ActivateSessionAsync(sessionId, ct);
        
        await t.CommitAsync(ct);

        return RepeatState.Active;
    }

    public Task ActivateSessionAsync(
        long sessionId,
        CancellationToken ct = default)
    {
        return context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.State, RepeatState.Active)
                .SetProperty(x => x.StartedAt, dateTimeProvider.UtcNow), ct);
    }
    
    public async Task<bool> TryFinishCurrentUserSessionAsync(Guid userId, CancellationToken ct = default)
    {
        var updatedCount = await context.RepeatSessions
            .Where(x => x.UserId == userId)
            .Where(x => x.State == RepeatState.Active)
            .Where(x => x.Words.All(w => 
                w.RepeatSessionWordState != RepeatSessionWordState.NotRepeated))
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.State, RepeatState.Finished)
                .SetProperty(x => x.FinishedAt, dateTimeProvider.UtcNow), ct);

        return updatedCount == 1;
    }

    public async Task LearnWordAsync(
        long sessionId,
        TranslationIdentifier translationIdentifier,
        CancellationToken ct = default)
    {
        await context.RepeatSessionTranslations
            .Where(x => x.RepeatSessionId == sessionId)
            .Where(x => x.TranslationId == translationIdentifier.TranslationId)
            .Where(x => x.Translation.MeaningId == translationIdentifier.MeaningId)
            .Where(x => x.Translation.WordId == translationIdentifier.WordId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(
                    x => x.RepeatSessionWordState,
                    RepeatSessionWordState.Repeated), ct);

        var userId = await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => x.UserId)
            .FirstOrDefaultAsyncEF(ct);

        await UpsertTranslationStateWithRepeatedStateAsync(userId, translationIdentifier, ct);
    }

    public Task<IFullPaginatedResult<LearningItem>> GetUnlearnedSessionWordsAsync(
        long sessionId,
        PaginatedRequest request,
        CancellationToken ct = default)
    {
        return context.RepeatSessionTranslations
            .Where(x => x.RepeatSessionId == sessionId)
            .LeftJoin(
                context.TranslationStates.AsQueryable(),
                (wg, wts) =>
                    wg.TranslationId == wts.TranslationId
                    && wg.RepeatSession.UserId == wts.UserId,
                (relation, state) => new { relation, state })
            .Where(x => x.relation.RepeatSessionWordState == RepeatSessionWordState.NotRepeated)
            .OrderBy(x => x.relation.CreatedAt)
            .Select((x, i) => new LearningItem(
                x.relation.Translation.Meaning.Word.Text,
                x.relation.Translation.Text,
                x.relation.Translation.Meaning.Text,
                request.Page * request.PerPage + i + 1,
                x.state.IsMarked,
                x.relation.Translation.Difficulty,
                new TranslationIdentifier
                {
                    TranslationId = x.relation.TranslationId,
                    MeaningId = x.relation.MeaningId,
                    WordId = x.relation.WordId
                },
                x.relation.Translation.Meaning.CefrLevel!.Name,
                x.relation.Translation.Meaning.Topics.Select(t => t.Topic.Name).ToArray(),
                x.state.LearnedAt,
                x.state.RepeatedAt))
            .FullPaginateLinq2DbAsync(request, ct);
    }

    private Task UpsertTranslationStateWithRepeatedStateAsync(
        Guid userId,
        TranslationIdentifier translationIdentifier,
        CancellationToken ct)
    {
        var now = dateTimeProvider.UtcNow;
        
        return context.TranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new TranslationState
                {
                    TranslationId = translationIdentifier.TranslationId,
                    MeaningId = translationIdentifier.MeaningId,
                    WordId = translationIdentifier.WordId,
                    UserId = userId,
                    LearnedAt = now,
                    LearnAttempts = 1,
                }, x => new TranslationState
                {
                    LearnedAt = x.LearnedAt ?? now,
                    RepeatedAt = x.LearnedAt != null ? now : null
                },
                () => new TranslationState
                {
                    UserId = userId,
                    TranslationId = translationIdentifier.TranslationId,
                    MeaningId = translationIdentifier.MeaningId,
                    WordId = translationIdentifier.WordId,
                },
                ct);
    }
}