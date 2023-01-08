using System;
using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Laraue.Apps.LearnEnglish.IntegrationTests;

public abstract class TestWithDatabase
{
    protected readonly IMediator _mediator;
    protected readonly IServiceProvider _provider;

    public record UsersData(string Id1, string Id2);

    protected UsersData Users { get; } = new (Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
    
    protected TestWithDatabase()
    {
        _provider = ServiceCollection.BuildServiceProvider();
        _mediator = _provider.GetRequiredService<IMediator>();
        
        var dbContext = _provider.GetRequiredService<DatabaseContext>();
        dbContext.Users.AddRange(
            new User { Id = Users.Id1 },
            new User { Id = Users.Id2 });
        dbContext.SaveChanges();
    }
    
    protected IServiceCollection ServiceCollection
    {
        get
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            var sc = new ServiceCollection()
                .AddMediatR(typeof(GetGroupWordsQuery))
                .AddDbContext<DatabaseContext>(opt =>
                {
                    opt.UseNpgsql(config.GetConnectionString("Postgre"))
                        .UseSnakeCaseNamingConvention();
                })
                .AddLinq2Db();

            return sc;
        }
    }
}