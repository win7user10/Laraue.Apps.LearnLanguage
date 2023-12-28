namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record RepeatSessionInfo(
    int WordsAddedToRepeatCount,
    int WordsRememberedCount,
    DateTime? StartedAt,
    DateTime? FinishedAt);