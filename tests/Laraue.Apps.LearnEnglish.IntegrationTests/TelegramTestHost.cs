using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Laraue.Telegram.NET.Abstractions;
using Laraue.Telegram.NET.Authentication.Services;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public class AppTelegramTestHost(IServiceCollection serviceCollection)
    : TelegramTestHost<Guid>(serviceCollection)
{
    protected override async Task BeforeFirstRequestAsync()
    {
        TestServer.Services.UseLinq2Db();

        var dbContext = GetRequiredService<DatabaseContext>();
        
        await dbContext.Database.MigrateAsync();

        await CleanDataAsync();
    }

    protected override async ValueTask DisposeAsync(bool disposing)
    {
        await CleanDataAsync();
    }

    private async Task CleanDataAsync()
    {
        await this.GetDbSet(db => db.Users).ExecuteDeleteAsync();
    }
}

public abstract class TelegramTestHost<TUserKey> : IAsyncDisposable where TUserKey : IEquatable<TUserKey>
{
    protected readonly TestServer TestServer;
    private readonly IServiceScope _serviceScope;
    private int _initialized;

    public TelegramTestHost(IServiceCollection serviceCollection)
    {
        var services = serviceCollection
            .AddSingleton(new Mock<ITelegramBotClient>().Object)
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