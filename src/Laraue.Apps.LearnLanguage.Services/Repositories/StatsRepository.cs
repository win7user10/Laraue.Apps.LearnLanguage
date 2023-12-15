using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Extensions;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DateTime.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class StatsRepository : IStatsRepository
{
    private readonly DatabaseContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;

    public StatsRepository(DatabaseContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<LearnStats> GetLearnStatsAsync(Guid userId, CancellationToken ct = default)
    {
        var getUserWordsQuery = _context.WordGroupWords
            .Where(x => x.WordGroup.UserId == userId)
            .QueryGroupWordsWithStates(_context, (word, state) => new
            {
                state.LearnState,
                state.LearnedAt,
            });
        
        var wordsCount = await getUserWordsQuery.CountAsync(ct);
        
        var learnedCount = await getUserWordsQuery
            .Where(x => (x.LearnState & LearnState.Learned) != 0)
            .CountAsync(ct);

        var firstLearnedAt = await getUserWordsQuery
            .OrderBy(x => x.LearnedAt)
            .Select(x => x.LearnedAt)
            .FirstAsync(ct);

        double? learnSpeed = null;
        DateOnly? approximateLearnWordsDate = null;
        if (firstLearnedAt is not null)
        {
            var learnDays = (DateTimeOffset.UtcNow - firstLearnedAt).Value.TotalDays;
            learnSpeed = learnedCount / learnDays;

            var daysToLearn = (int)Math.Ceiling((wordsCount - learnedCount) / learnSpeed.Value);
            approximateLearnWordsDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(daysToLearn));
        }

        var totalStat = new TotalStat(learnedCount, wordsCount, learnSpeed, approximateLearnWordsDate);

        var daysStat = await getUserWordsQuery
            .Where(x => x.LearnedAt != null)
            .GroupBy(x => x.LearnedAt!.Value.Date)
            .OrderByDescending(x => x.Key)
            .Select(x => new DayLearnStats(x.Key, x.Count()))
            .Take(10)
            .ToListAsync(ct);

        return new LearnStats(totalStat, daysStat);
    }

    public async Task<IList<UserDailyStats>> GetYesterdayAllUsersStatsAsync(CancellationToken ct = default)
    {
        var yesterdayDate = _dateTimeProvider.UtcNow.AddDays(-1).Date;
        
        return await _context
            .Users
            .Where(x => x.WordTranslationStates
                .Any(y => y.LearnedAt.HasValue
                          && y.LearnedAt.Value.Date == yesterdayDate))
            .Select(x => new UserDailyStats
            (
                x.TelegramId!.Value,
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue
                                && y.LearnedAt.Value.Date == yesterdayDate),
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue),
                x.WordGroups.Sum(y => y.WordGroupWords.Count)
            ))
            .ToListAsync(ct);
    }

    public async Task IncrementSeenCountAsync(Guid userId, long[] wordTranslationIds, CancellationToken ct = default)
    {
        var updatedCount = await _context.WordTranslationStates
            .Where(x =>
                wordTranslationIds.Contains(x.WordTranslationId)
                && userId == x.UserId)
            .ExecuteUpdateAsync(u =>
                u.SetProperty(x => x.ViewCount, x => x.ViewCount + 1), ct);

        if (updatedCount == wordTranslationIds.Length)
        {
            return;
        }
        
        var existsStates = await _context.WordTranslationStates
            .Where(x =>
                wordTranslationIds.Contains(x.WordTranslationId)
                && userId == x.UserId)
            .Select(x => x.WordTranslationId)
            .ToListAsync(ct);

        foreach (var wordTranslationId in wordTranslationIds.Except(existsStates))
        {
            _context.WordTranslationStates.Add(new WordTranslationState
            {
                ViewCount = 1,
                WordTranslationId = wordTranslationId,
                UserId = userId,
            });
        }

        await _context.SaveChangesAsync(ct);
    }
}