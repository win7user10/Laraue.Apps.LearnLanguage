using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IWordsRepository
{
    /// <summary>
    /// Returns available pairs for the learning.
    /// </summary>
    Task<List<LearningLanguagePair>> GetAvailableLearningPairsAsync(CancellationToken ct = default);
}