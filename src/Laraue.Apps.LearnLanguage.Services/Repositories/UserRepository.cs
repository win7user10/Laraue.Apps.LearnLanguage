using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Repositories;

public class UserRepository(DatabaseContext context) : IUserRepository
{
    public Task<UserViewSettings> GetViewSettingsAsync(Guid userId, CancellationToken ct = default)
    {
        return context.Users
            .Where(x => x.Id == userId)
            .Select(x => new UserViewSettings(
                x.WordsTemplateMode,
                x.ShowWordsMode))
            .FirstAsyncEF(ct);
    }

    public async Task UpdateViewSettings(Guid userId, IChangeUserSettingsRequest request, CancellationToken ct = default)
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

    public Task<UserSettings> GetSettingsAsync(Guid userId, CancellationToken ct = default)
    {
        return context.Users.Where(x => x.Id == userId)
            .Select(x => new UserSettings(
                x.TelegramLanguageCode,
                x.LanguageToLearnId,
                x.LanguageToLearnFromId,
                x.LanguageToLearn.Code,
                x.LanguageToLearnFrom.Code))
            .FirstAsyncEF(ct);
    }

    public Task SetLanguageCodeAsync(Guid userId, string code, CancellationToken ct = default)
    {
        return context.Users
            .Where(x => x.Id == userId)
            .UpdateAsync(_ => new User
            {
                TelegramLanguageCode = code
            }, ct);
    }

    public Task UpdateLanguageSettingsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        return context.Users
            .Where(x => x.Id == userId)
            .UpdateAsync(_ => new User
            {
                LanguageToLearnFromId = selectedTranslation.LanguageToLearnFromId,
                LanguageToLearnId = selectedTranslation.LanguageToLearnId,
            }, ct);
    }

    private Task ToggleWordsTemplateModeAsync(
        Guid userId,
        WordsTemplateMode flagToChange,
        CancellationToken ct = default)
    {
        return context.Users
            .Where(x => x.Id == userId)
            .UpdateAsync(x => new User
            {
                WordsTemplateMode = x.WordsTemplateMode ^ flagToChange
            }, ct);
    }

    private Task SetShowWordsModeAsync(Guid userId, ShowWordsMode value, CancellationToken ct = default)
    {
        return context.Users
            .Where(x => x.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(x => x.ShowWordsMode, value), ct);
    }
}