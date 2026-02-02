namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public sealed record AdminStats(
    int TotalUsersCount,
    int ActiveWeekUsersCount,
    int UsersHaveAnyQuizCount,
    IList<RegisteredUsers> RegisteredUsers);

public sealed record RegisteredUsers(DateTime Date, int Count);