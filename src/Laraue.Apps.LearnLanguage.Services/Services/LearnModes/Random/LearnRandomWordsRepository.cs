using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
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

    public async Task<NextRepeatWordTranslation> GetNextRepeatWordAsync(
        long sessionId,
        NextWordPreference wordPreference,
        CancellationToken ct = default)
    {
        var userId = await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => x.UserId)
            .FirstAsyncLinqToDB(ct);
        
        var query = context.WordTranslations
            .Where(x => !context.RepeatSessionWords
                .Where(y => y.RepeatSessionId == sessionId)
                .Select(y => y.WordTranslationId)
                .Contains(x.Id))
            .LeftJoin(
                context.WordTranslationStates.AsQueryable(),
                (wt, wts) => wt.Id == wts!.WordTranslationId && wts.UserId == userId,
                (wt, wts) => new { wt, wts })
            .Select(x => new NextRepeatWordTranslation(
                x.wt.Id,
                x.wt.WordMeaning.Word.Name,
                x.wt.Translation,
                x.wts.LearnedAt,
                x.wts.RepeatedAt,
                x.wts.LearnAttempts,
                x.wt.WordMeaning.WordCefrLevel!.Name,
                x.wt.WordMeaning.Topics.Select(t => t.WordTopic.Name).ToArray(),
                x.wt.Difficulty))
            .OrderBy(x => x.LearnedAt.HasValue)
            .ThenByDescending(x => x.RepeatedAt);

        switch (wordPreference)
        {
            case NextWordPreference.MostSeen:
                query = query.ThenByDescending(x => x.LearnAttempts);
                break;
            case NextWordPreference.LeastSeen:
                query = query.ThenBy(x => x.LearnAttempts);
                break;
            case NextWordPreference.Random:
                query = query.ThenBy(_ => Linq2db.NewGuid());
                break;
        }

        return await query.FirstAsyncLinqToDB(ct);
    }

    public Task<NextRepeatWordTranslation> GetRepeatWordAsync(
        Guid userId,
        long translationId,
        CancellationToken ct = default)
    {
        return context.WordTranslations
            .Where(x => x.Id == translationId)
            .LeftJoin(
                context.WordTranslationStates.AsQueryable(),
                (wt, wts) => wt.Id == wts!.WordTranslationId && wts.UserId == userId,
                (wt, wts) => new { wt, wts })
            .Select(x => new NextRepeatWordTranslation(
                x.wt.Id,
                x.wt.WordMeaning.Word.Name,
                x.wt.Translation,
                x.wts.LearnedAt,
                x.wts.RepeatedAt,
                x.wts.LearnAttempts,
                x.wt.WordMeaning.WordCefrLevel!.Name,
                x.wt.WordMeaning.Topics.Select(t => t.WordTopic.Name).ToArray(),
                x.wt.Difficulty))
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
                x.StartedAt,
                x.FinishedAt))
            .FirstAsyncEF(ct);
    }

    public async Task<long> CreateSessionAsync(Guid userId, CancellationToken ct = default)
    {
        var session = new RepeatSession
        {
            UserId = userId
        };

        context.RepeatSessions.Add(session);
        await context.SaveChangesAsync(ct);

        return session.Id;
    }

    public async Task<RepeatState> AddWordToSessionAsync(
        long sessionId,
        long translationId,
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
                AlreadyAdded = x.Words.Any(y => y.WordTranslationId == translationId)
            })
            .FirstAsyncEF(ct);

        if (info.State != RepeatState.Filling
            || info.WordsCount >= Constants.RepeatModeGroupSize
            || info.AlreadyAdded)
        {
            return info.State;
        }
        
        var word = new RepeatSessionWordTranslation
        {
            WordTranslationId = translationId,
            RepeatSessionId = sessionId,
            RepeatSessionWordState = isRemembered
                ? RepeatSessionWordState.RepeatedSinceFirstAttempt
                : RepeatSessionWordState.NotRepeated
        };

        context.Add(word);
        await context.SaveChangesAsync(ct);

        if (isRemembered)
        {
            await UpsertTranslationStateWithRepeatedStateAsync(info.UserId, translationId, ct);
        }

        var newAddedWordsCount = isRemembered ? info.WordsCount : info.WordsCount + 1;
        if (newAddedWordsCount != Constants.RepeatModeGroupSize)
        {
            await t.CommitAsync(ct);
            return info.State;
        }
        
        await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.State, RepeatState.Active)
                .SetProperty(x => x.StartedAt, dateTimeProvider.UtcNow), ct);
        
        await t.CommitAsync(ct);

        return RepeatState.Active;
    }

    public async Task<bool> LearnWordAsync(long sessionId, long translationId, CancellationToken ct = default)
    {
        await context.RepeatSessionWords
            .Where(x => x.RepeatSessionId == sessionId)
            .Where(x => x.WordTranslationId == translationId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(
                    x => x.RepeatSessionWordState,
                    RepeatSessionWordState.Repeated), ct);

        var userId = await context.RepeatSessions
            .Where(x => x.Id == sessionId)
            .Select(x => x.UserId)
            .FirstOrDefaultAsyncEF(ct);

        await UpsertTranslationStateWithRepeatedStateAsync(userId, translationId, ct);

        var hasUnlearned = await context.RepeatSessionWords
            .Where(x => x.RepeatSessionId == sessionId)
            .Where(x => x.RepeatSessionWordState == RepeatSessionWordState.NotRepeated)
            .AnyAsyncEF(ct);

        if (hasUnlearned)
        {
            return false;
        }
        
        await context.RepeatSessions
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.State, RepeatState.Finished)
                .SetProperty(x => x.FinishedAt, dateTimeProvider.UtcNow), ct);

        return true;
    }

    public Task<IFullPaginatedResult<LearningItem>> GetUnlearnedSessionWordsAsync(
        long sessionId,
        PaginatedRequest request,
        CancellationToken ct = default)
    {
        return context.RepeatSessionWords
            .Where(x => x.RepeatSessionId == sessionId)
            .LeftJoin(
                context.WordTranslationStates.AsQueryable(),
                (wg, wts) =>
                    wg.WordTranslationId == wts.WordTranslationId
                    && wg.RepeatSession.UserId == wts.UserId,
                (relation, state) => new { relation, state })
            .Where(x => x.relation.RepeatSessionWordState == RepeatSessionWordState.NotRepeated)
            .OrderBy(x => x.relation.Id)
            .Select((x, i) => new LearningItem(
                x.relation.WordTranslation.WordMeaning.Word.Name,
                x.relation.WordTranslation.Translation,
                x.relation.WordTranslation.WordMeaning.Meaning,
                request.Page * request.PerPage + i + 1,
                x.state.IsMarked,
                x.relation.WordTranslation.Difficulty,
                x.relation.WordTranslationId,
                x.relation.WordTranslation.WordMeaning.WordCefrLevel!.Name,
                x.relation.WordTranslation.WordMeaning.Topics.Select(t => t.WordTopic.Name).ToArray(),
                x.state.LearnedAt,
                x.state.RepeatedAt))
            .FullPaginateLinq2DbAsync(request, ct);
    }

    private Task UpsertTranslationStateWithRepeatedStateAsync(Guid userId, long translationId, CancellationToken ct)
    {
        var now = dateTimeProvider.UtcNow;
        
        return context.WordTranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new WordTranslationState
                {
                    WordTranslationId = translationId,
                    UserId = userId,
                    LearnedAt = now,
                    LearnAttempts = 1,
                }, x => new WordTranslationState
                {
                    LearnedAt = x.LearnedAt ?? now,
                    RepeatedAt = x.LearnedAt != null ? now : null
                },
                () => new WordTranslationState
                {
                    UserId = userId,
                    WordTranslationId = translationId,
                },
                ct);
    }
}