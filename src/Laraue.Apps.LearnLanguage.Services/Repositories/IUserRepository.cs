using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Get user settings.
    /// </summary>
    Task<UserSettings> GetSettingsAsync(Guid userId, CancellationToken ct = default);

    /// <summary>
    /// Update identifiers of last viewed translations for the user.
    /// </summary>
    Task UpdateLastViewedTranslationsAsync(Guid userId, long[] wordTranslationIds, CancellationToken ct = default);

    /// <summary>
    /// Update passed set of settings.
    /// </summary>
    Task UpdateViewSettings(Guid userId, ChangeUserSettings request, CancellationToken ct = default);
}