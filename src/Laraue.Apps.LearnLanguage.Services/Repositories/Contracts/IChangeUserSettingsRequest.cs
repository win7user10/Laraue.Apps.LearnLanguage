using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public interface IChangeUserSettingsRequest
{
    public bool ToggleShowTranslations { get; init; }
    
    public bool ToggleRevertTranslations { get; init; }
    
    public ShowWordsMode? ShowMode { get; init; }
}