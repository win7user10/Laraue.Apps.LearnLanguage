using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.DataAccess;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public abstract record BaseLearnRequest : IChangeUserSettingsRequest, IUpdateWordStateRequest
{
    [FromQuery(ParameterNames.ToggleTranslations)]
    public bool ToggleShowTranslations { get; init; }
    
    [FromQuery(ParameterNames.RevertTranslations)]
    public bool ToggleRevertTranslations { get; init; }
    
    [FromQuery(ParameterNames.ShowMode)]
    public ShowWordsMode? ShowMode { get; init; }
    
    [FromQuery(Defaults.PageParameterName)]
    public int Page { get; init; }
    
    [FromQuery(ParameterNames.OpenedTranslationId)]
    public long? OpenedWordTranslationId { get; init; }
    
    [FromQuery(ParameterNames.LearnState)]
    public bool? IsLearned  { get; init; }
    
    [FromQuery(ParameterNames.MarkState)]
    public bool? IsMarked  { get; init; }
}