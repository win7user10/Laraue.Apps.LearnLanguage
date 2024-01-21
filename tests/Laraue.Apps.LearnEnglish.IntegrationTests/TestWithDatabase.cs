using System;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

[Collection("DatabaseTests")]
public abstract class TestWithDatabase
{
    protected TestWithDatabase()
    {
        LinqToDBForEFTools.Initialize();
        GetDbContext().Database.Migrate();
        ClearDb();
        SeedDb();
    }
    
    protected DatabaseContext GetDbContext()
    {
        return new(new DbContextOptionsBuilder()
            .UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=test_learn_language;Command Timeout=0")
            .UseSnakeCaseNamingConvention()
            .Options);
    }

    private void ClearDb()
    {
        GetDbContext().Users.Delete();
    }
    
    private void SeedDb()
    {
        var dbContext = GetDbContext();
        dbContext.Users.AddRange(Users.User1, Users.User2);
        dbContext.SaveChanges();
    }

    protected IServiceCollection ServiceCollection
    {
        get
        {
            var sc = new ServiceCollection()
                .AddScoped<DatabaseContext>(_ => GetDbContext())
                .AddLinq2Db();

            return sc;
        }
    }

    protected record UsersData(User User1, User User2);

    protected UsersData Users { get; } = new(
        new User() { Id = Guid.NewGuid(), TelegramId = 1 },
        new User() { Id = Guid.NewGuid(), TelegramId = 2 });
}