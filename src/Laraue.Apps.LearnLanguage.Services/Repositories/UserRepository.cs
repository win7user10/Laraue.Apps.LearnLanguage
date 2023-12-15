using Laraue.Apps.LearnLanguage.DataAccess;
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

    public Task ToggleWordsTemplateModeAsync(
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

    public Task SetShowWordsModeAsync(Guid userId, ShowWordsMode value, CancellationToken ct = default)
    {
        return _context.Users
            .Where(x => x.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.ShowWordsMode, value), ct);
    }
}