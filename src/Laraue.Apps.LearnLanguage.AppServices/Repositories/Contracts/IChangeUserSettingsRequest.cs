using Laraue.Apps.LearnLanguage.Contracts.Enums;

namespace Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;

public interface IChangeUserSettingsRequest
{
    public bool ToggleShowTranslations { get; init; }
    
    public bool ToggleRevertTranslations { get; init; }
    
    public ShowWordsMode? ShowMode { get; init; }
}