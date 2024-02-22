using Laraue.Apps.LearnLanguage.Services.Services.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IUserSettingsService
{
    Task HandleSettingsViewAsync(ReplyData replyData, CancellationToken ct = default);
    
    Task HandleInterfaceLanguageSettingsViewAsync(
        ReplyData replyData,
        UpdateInterfaceLanguageSettingsRequest request,
        CancellationToken ct = default);
    
    Task HandleLearnLanguageSettingsViewAsync(ReplyData replyData, CancellationToken ct = default);
    
    Task UpdateLearnLanguageSettingsAsync(
        ReplyData replyData,
        UpdateLearnLanguageSettingsRequest request,
        CancellationToken ct = default);
}