namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IWordsRepository
{
    /// <summary>
    /// Update learn state of the translation.
    /// </summary>
    /// <returns></returns>
    Task ChangeWordLearnStateAsync(
        Guid userId,
        long wordTranslationId,
        bool? isLearned,
        bool? isMarked,
        CancellationToken ct = default);
    
    /// <summary>
    /// Increment seen counter for the passed translations.
    /// </summary>
    Task IncrementLearnAttemptsIfRequiredAsync(Guid userId, long[] wordTranslationIds, CancellationToken ct = default);
}