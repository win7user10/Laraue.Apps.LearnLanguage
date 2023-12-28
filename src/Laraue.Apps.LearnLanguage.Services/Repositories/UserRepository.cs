﻿using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<UserSettings> GetSettingsAsync(Guid userId, CancellationToken ct = default)
    {
        return _context.Users
            .Where(x => x.Id == userId)
            .Select(x => new UserSettings(x.WordsTemplateMode, x.ShowWordsMode, x.LastOpenedTranslationIds))
            .FirstAsyncEF(ct);
    }

    public async Task UpdateViewSettings(Guid userId, ChangeUserSettings request, CancellationToken ct = default)
    {
        if (request.ToggleShowTranslations)
        {
            await ToggleWordsTemplateModeAsync(
                userId,
                WordsTemplateMode.HideTranslations,
                ct);
        }
        
        if (request.ToggleRevertTranslations)
        {
            await ToggleWordsTemplateModeAsync(
                userId,
                WordsTemplateMode.RevertWordAndTranslation,
                ct);
        }

        if (request.ShowMode is not null)
        {
            await SetShowWordsModeAsync(
                userId,
                request.ShowMode.GetValueOrDefault(),
                ct);
        }
    }

    public Task UpdateLastViewedTranslationsAsync(
        Guid userId,
        long[] wordTranslationIds,
        CancellationToken ct = default)
    {
        return _context.Users
            .Where(x => x.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.LastOpenedTranslationIds, wordTranslationIds), ct);
    }

    private Task ToggleWordsTemplateModeAsync(
        Guid userId,
        WordsTemplateMode flagToChange,
        CancellationToken ct = default)
    {
        return _context.Users
            .Where(x => x.Id == userId)
            .UpdateAsync(x => new User
            {
                WordsTemplateMode = x.WordsTemplateMode ^ flagToChange
            }, ct);
    }

    private Task SetShowWordsModeAsync(Guid userId, ShowWordsMode value, CancellationToken ct = default)
    {
        return _context.Users
            .Where(x => x.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.ShowWordsMode, value), ct);
    }
}