using Telegram.Bot.Requests;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Library;

public static class AssertExtensions
{
    extension(EditMessageTextRequest request)
    {
        public void HasMessage(string expected)
        {
            Assert.Equal(expected, request.Text);
        }
    }
}