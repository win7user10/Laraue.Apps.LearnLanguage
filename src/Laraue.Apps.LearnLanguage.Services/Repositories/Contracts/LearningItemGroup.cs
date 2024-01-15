namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record LearningItemGroup<TId>(
    TId Id,
    int LearnedCount,
    int TotalCount,
    string Name) where TId : struct;