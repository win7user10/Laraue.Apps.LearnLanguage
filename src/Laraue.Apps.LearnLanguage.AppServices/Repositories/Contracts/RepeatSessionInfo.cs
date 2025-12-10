namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public record RepeatSessionInfo(
    int WordsAddedToRepeatCount,
    int WordsRememberedCount,
    int MaxWordsInSessionCount,
    DateTime? StartedAt,
    DateTime? FinishedAt);