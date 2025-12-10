using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories;

public interface IWordsRepository
{
    /// <summary>
    /// Returns available pairs for the learning.
    /// </summary>
    Task<List<LearningLanguagePair>> GetAvailableLearningPairsAsync(CancellationToken ct = default);
}