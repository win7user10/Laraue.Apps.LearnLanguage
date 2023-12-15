using System;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public abstract class TestWithDatabase
{
    protected readonly DatabaseContext DbContext;
    
    protected TestWithDatabase()
    {
        DbContext = new DatabaseContext(new DbContextOptionsBuilder()
            .UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=test_learn_language;Command Timeout=0")
            .UseSnakeCaseNamingConvention()
            .Options);
        
        LinqToDBForEFTools.Initialize();
        DbContext.Database.Migrate();
        ClearDb();
        SeedDb();
    }

    private void ClearDb()
    {
        DbContext.Users.Delete();
    }
    
    private void SeedDb()
    {
        DbContext.Users.AddRange(Users.User1, Users.User2);
        DbContext.SaveChanges();
    }

    protected IServiceCollection ServiceCollection
    {
        get
        {
            var sc = new ServiceCollection()
                .AddScoped<DatabaseContext>(_ => DbContext)
                .AddLinq2Db();

            return sc;
        }
    }

    protected record UsersData(User User1, User User2);

    protected UsersData Users { get; } = new(
        new User() { Id = Guid.NewGuid(), TelegramId = 1 },
        new User() { Id = Guid.NewGuid(), TelegramId = 2 });
}