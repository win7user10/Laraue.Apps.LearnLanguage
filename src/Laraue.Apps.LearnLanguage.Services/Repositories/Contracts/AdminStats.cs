namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record AdminStats(
    int TotalUsersCount,
    IList<RegisteredUsers> RegisteredUsers,
    IList<ActiveUser> ActiveUsers);

public sealed record RegisteredUsers(DateTime Date, int Count);
public sealed record ActiveUser(long TelegramId, int LearnedCount, int RepeatedCount);