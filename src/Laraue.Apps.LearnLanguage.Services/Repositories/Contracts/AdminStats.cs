namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public sealed record AdminStats(
    int TotalUsersCount,
    int RegisteredUsersCount,
    int LearnedCount,
    IList<ActiveUser> ActiveUsers);

public sealed record ActiveUser(Guid Id, int LearnedCount);