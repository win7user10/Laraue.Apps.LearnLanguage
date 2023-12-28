using Laraue.Apps.LearnLanguage.DataAccess.Entities;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record RepeatSessionState(long Id, RepeatState State);