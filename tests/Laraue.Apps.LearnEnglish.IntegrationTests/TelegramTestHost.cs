using Laraue.Apps.LearnEnglish.IntegrationTests.Library;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public class AppTelegramTestHost(IServiceCollection serviceCollection)
    : TelegramTestHost<Guid>(serviceCollection)
{
    protected override void BeforeFirstRequest()
    {
        TestServer.Services.UseLinq2Db();
        
        using var scope = CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        dbContext.Database.Migrate();
        dbContext.Users.ExecuteDelete();
    }

    protected override void Dispose(bool disposing)
    {
        using var scope = CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        dbContext.Users.ExecuteDelete();
    }
}