﻿using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public interface IUserRepository
{
    /// <summary>
    /// Get user settings.
    /// </summary>
    Task<UserViewSettings> GetViewSettingsAsync(Guid userId, CancellationToken ct = default);

    /// <summary>
    /// Update passed set of settings.
    /// </summary>
    Task UpdateViewSettings(Guid userId, IChangeUserSettingsRequest request, CancellationToken ct = default);
    
    Task<UserSettings> GetSettingsAsync(Guid userId, CancellationToken ct = default);
    
    Task SetLanguageCodeAsync(Guid userId, string code, CancellationToken ct = default);
    
    Task UpdateLanguageSettingsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default);
}