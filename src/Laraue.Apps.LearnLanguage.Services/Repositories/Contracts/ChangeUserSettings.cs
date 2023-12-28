using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record ChangeUserSettings
{
    [FromQuery(ParameterNames.ToggleTranslations)]
    public bool ToggleShowTranslations { get; init; }
    
    [FromQuery(ParameterNames.RevertTranslations)]
    public bool ToggleRevertTranslations { get; init; }
    
    [FromQuery(ParameterNames.ShowMode)]
    public ShowWordsMode? ShowMode { get; init; }
}