namespace Laraue.Apps.LearnLanguage.Common.Services;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}