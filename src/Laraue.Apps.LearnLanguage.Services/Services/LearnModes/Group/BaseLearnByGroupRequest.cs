using Laraue.Apps.LearnLanguage.Common;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public abstract record BaseLearnByGroupRequest<TId> : BaseLearnRequest where TId : struct
{
    /// <summary>
    /// Cefr level of words that should be opened.
    /// </summary>
    [FromQuery(ParameterNames.GroupId)]
    public TId GroupId { get; set; }
}