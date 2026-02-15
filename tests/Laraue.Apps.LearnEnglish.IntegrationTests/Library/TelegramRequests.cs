using Telegram.Bot.Requests.Abstractions;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Library;

public class TelegramRequests(List<IRequest> requests)
{
    public IReadOnlyList<IRequest> Source { get; } = requests;

    public T Single<T>() where T : class, IRequest
    {
        var item = Single();
        return Assert.IsType<T>(item);
    }
        
    public IRequest Single()
    {
        return Assert.Single(Source);
    }
}