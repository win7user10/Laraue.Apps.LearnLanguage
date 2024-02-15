using Laraue.Apps.LearnLanguage.Common;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;

public record DetailView : BaseDetailView
{
    [FromQuery(ParameterNames.SessionId)]
    public long SessionId { get; init; }
}