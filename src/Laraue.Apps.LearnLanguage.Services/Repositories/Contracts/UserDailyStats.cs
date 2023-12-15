namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record UserDailyStats(
    long TelegramId,
    int LearnedYesterdayCount,
    int LearnedTotalCount,
    int TotalWordsCount);