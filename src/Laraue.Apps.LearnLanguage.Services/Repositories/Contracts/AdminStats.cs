namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record AdminStats(
    int TotalUsersCount,
    int ActiveUsersCount,
    IList<RegisteredUsers> RegisteredUsers,
    IList<ActiveUsers> ActiveUsers);

public sealed record RegisteredUsers(DateTime Date, int Count);
public sealed record ActiveUsers(DateTime Date, int Count);