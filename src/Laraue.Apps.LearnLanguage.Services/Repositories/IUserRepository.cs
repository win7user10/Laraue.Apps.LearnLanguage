using Laraue.Apps.LearnLanguage.DataAccess.Enums;
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
    /// Toggle WordsTemplateMode value to the opposite state.
    /// </summary>
    Task ToggleWordsTemplateModeAsync(Guid userId, WordsTemplateMode flagToChange, CancellationToken ct = default);
    
    /// <summary>
    /// Update ShowWordsMode for the user.
    /// </summary>
    Task SetShowWordsModeAsync(Guid userId, ShowWordsMode value, CancellationToken ct = default);
}