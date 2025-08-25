namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record AdminStats(
    int TotalUsersCount,
    int ActiveUsersCount,
    IList<RegisteredUsers> RegisteredUsers);

public sealed record RegisteredUsers(DateTime Date, int Count);