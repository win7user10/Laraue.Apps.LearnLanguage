using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Laraue.Core.Exceptions;
using Laraue.Telegram.NET.Authentication.Extensions;
using Laraue.Telegram.NET.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Hangfire;
using Hangfire.PostgreSql;
using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Jobs;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Core.DateTime.Services.Abstractions;
using Laraue.Core.DateTime.Services.Impl;
using Laraue.Telegram.NET.Authentication.Services;
using Laraue.Telegram.NET.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
    .AddSingleton<ExceptionHandleMiddleware>()
    .AddTelegramCore(new TelegramBotClientOptions(builder.Configuration["Telegram:Token"]))
    .AddTelegramMiddleware<AutoCallbackResponseMiddleware>()
    .AddTelegramAuthentication<User, Guid, RequestContext>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOptions<RoleUsers>();
builder.Services.Configure<RoleUsers>(builder.Configuration.GetSection("Telegram:Roles"));
builder.Services.UseUserRolesProvider<StaticUserRoleProvider>();

builder.Services.AddScoped<IStatsService, StatsService>()
    .AddScoped<ISequentialModeService, SequentialModeService>()
    .AddScoped<IRepeatModeService, RepeatModeService>()
    .AddScoped<IRepeatModeRepository, RepeatModeRepository>()
    .AddScoped<IWordsRepository, WordsRepository>()
    .AddScoped<IWordsWindowFactory, WordsWindowFactory>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IStatsRepository, StatsRepository>()
    .AddScoped<ISequentialModeRepository, SequentialModeRepository>()
    .AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Postgre");

builder.Services
    .AddDbContext<DatabaseContext>(opt =>
    {
        opt.UseNpgsql(connection)
            .UseSnakeCaseNamingConvention();
    })
    .AddLinq2Db();

builder.Services
    .AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(o => o.UseNpgsqlConnection(connection)))
    .AddHangfireServer();

var app = builder.Build();

app.Services.UseLinq2Db();

app.MapTelegramRequests(builder.Configuration["Telegram:WebhookUrl"]);

using (var scope = app.Services.CreateScope())
{
    await using var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await db.Database.MigrateAsync();

    var jobClient = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    
    jobClient.AddOrUpdate<CalculateDailyStatJob>(
        nameof(CalculateDailyStatJob),
        x => x.ExecuteAsync(),
        Cron.Daily);
    
    jobClient.AddOrUpdate<UpdateTranslationsComplexityJob>(
        nameof(UpdateTranslationsComplexityJob),
        x => x.ExecuteAsync(),
        Cron.Hourly);
}

app.Run();