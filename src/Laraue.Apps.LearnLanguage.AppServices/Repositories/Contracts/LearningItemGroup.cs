namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public record LearningItemGroup<TId>(
    TId Id,
    int LearnedCount,
    int TotalCount,
    string Name) where TId : struct;