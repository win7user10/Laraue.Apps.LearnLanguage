namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public sealed record UserDailyStats(
    long TelegramId,
    int LearnedYesterdayCount,
    int LearnedTotalCount,
    int TotalWordsCount);