using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public interface ILearnRandomWordsRepository
{
    /// <summary>
    /// Returns active repeat session for the user if it is exists.
    /// </summary>
    Task<RepeatSessionState?> GetRepeatSessionStateAsync(Guid userId, CancellationToken ct = default);
    
    /// <summary>
    /// Next suggested word to repeat.
    /// </summary>
    Task<NextRepeatWordTranslation?> GetNextRepeatWordAsync(
        long sessionId,
        NextWordPreference wordPreference,
        CancellationToken ct = default);
    
    Task<NextRepeatWordTranslation> GetRepeatWordAsync(
        Guid userId,
        TranslationIdentifier translationIdentifier,
        CancellationToken ct = default);
    
    Task<RepeatSessionInfo> GetSessionInfoAsync(long sessionId, CancellationToken ct = default);

    Task<long> CreateSessionAsync(Guid userId, SelectedTranslation selectedTranslation, CancellationToken ct = default);

    /// <summary>
    /// Create relation between translation and session.
    /// </summary>
    /// <returns>Actual session state.</returns>
    Task<RepeatState> AddWordToSessionAsync(
        long sessionId,
        TranslationIdentifier translationIdentifier,
        bool isRemembered,
        CancellationToken ct = default);

    /// <summary>
    /// Mark word as learned in the repeating session.
    /// </summary>
    /// <returns>Is session finished.</returns>
    Task LearnWordAsync(
        long sessionId,
        TranslationIdentifier translationIdentifier,
        CancellationToken ct = default);

    Task ActivateSessionAsync(
        long sessionId,
        CancellationToken ct = default);

    Task<bool> TryFinishCurrentUserSessionAsync(Guid userId, CancellationToken ct = default);

    Task<IFullPaginatedResult<LearningItem>> GetUnlearnedSessionWordsAsync(
        long sessionId,
        PaginatedRequest request,
        CancellationToken ct = default);
}