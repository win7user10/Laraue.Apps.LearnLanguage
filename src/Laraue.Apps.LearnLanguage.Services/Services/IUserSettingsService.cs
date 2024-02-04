using Laraue.Apps.LearnLanguage.Services.Services.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IUserSettingsService
{
    Task HandleSettingsViewAsync(ReplyData replyData, CancellationToken ct = default);
    Task HandleLanguageSettingsViewAsync(
        ReplyData replyData,
        UpdateSettingsRequest request,
        CancellationToken ct = default);
}