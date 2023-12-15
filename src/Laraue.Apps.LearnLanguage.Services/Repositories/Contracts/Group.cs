namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record Group(long Id, long SerialNumber, string FirstWord, int LearnedCount, int TotalCount);