using Laraue.Apps.LearnEnglish.IntegrationTests.Library;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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