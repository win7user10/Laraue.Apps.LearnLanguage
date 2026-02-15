using Laraue.Telegram.NET.Abstractions;
using Laraue.Telegram.NET.Authentication.Services;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Telegram.Bot;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnEnglish.IntegrationTests.Library;

public abstract class TelegramTestHost<TUserKey> : IAsyncDisposable where TUserKey : IEquatable<TUserKey>
{
    protected readonly TestServer TestServer;
    private readonly IServiceScope _serviceScope;
    private int _initialized;
    private readonly List<IRequest> _requests = new();

    public TelegramTestHost(IServiceCollection serviceCollection)
    {
        var botClient = new Mock<ITelegramBotClient>();

        botClient
            .Setup(c => c
                .SendRequest(
                    It.IsAny<IRequest<It.IsAnyType>>(),
                    It.IsAny<CancellationToken>()))
            .Callback((object request, CancellationToken cancellationToken) =>
            {
                _requests.Add((IRequest)request);
            });
        
        var services = serviceCollection
            .AddSingleton(botClient.Object)
            .AddSingleton(new Mock<IUserIdByTelegramIdCache<TUserKey>>().Object)
            .BuildServiceProvider();
        
        TestServer = new TestServer(services);
        _serviceScope = TestServer.Services.CreateScope();
    }

    protected abstract Task BeforeFirstRequestAsync();
    
    public async Task SendUpdateAsync(Update update)
    {
        if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 0)
        {
            await BeforeFirstRequestAsync();
        }
        
        using var requestScope = TestServer.Services.CreateScope();

        var router = requestScope.ServiceProvider.GetRequiredService<ITelegramRouter>();
        
        await router.RouteAsync(update);
    }

    public TelegramRequests Requests()
    {
        return new TelegramRequests(_requests);
    }
    
    public T GetRequiredService<T>()
        where T : class
    {
        return _serviceScope.ServiceProvider.GetRequiredService<T>();
    }

    protected virtual ValueTask DisposeAsync(bool disposing)
    {
        if (disposing)
        {
            TestServer.Dispose();
            _serviceScope.Dispose();
        }
        
        return ValueTask.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
}