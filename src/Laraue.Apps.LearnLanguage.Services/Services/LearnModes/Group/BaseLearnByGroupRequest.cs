using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;
using Laraue.Telegram.NET.DataAccess;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public abstract record BaseLearnByGroupRequest<TId> : ChangeUserSettings where TId : struct
{
    /// <summary>
    /// Page number to open.
    /// </summary>
    [FromQuery(Defaults.PageParameterName)]
    public int Page { get; init; }
    
    /// <summary>
    /// Id of the opened translation.
    /// </summary>
    [FromQuery(ParameterNames.OpenedTranslationId)]
    public long? OpenedWordTranslationId { get; init; }
    
    /// <summary>
    /// When passed, learn state of the opened translation will be changed to this value.
    /// </summary>
    [FromQuery(ParameterNames.LearnState)]
    public LearnState? LearnState  { get; init; }
    
    /// <summary>
    /// Cefr level of words that should be opened.
    /// </summary>
    [FromQuery(ParameterNames.GroupId)]
    public TId GroupId { get; set; }
}