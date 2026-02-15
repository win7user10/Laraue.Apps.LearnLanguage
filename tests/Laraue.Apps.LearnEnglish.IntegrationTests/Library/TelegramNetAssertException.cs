namespace Laraue.Apps.LearnEnglish.IntegrationTests.Library;

public class TelegramNetAssertException : Exception
{
    public TelegramNetAssertException(string message) : base(message)
    {
    }
}