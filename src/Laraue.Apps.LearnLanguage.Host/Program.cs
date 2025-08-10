using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Laraue.Telegram.NET.Authentication.Extensions;
using Laraue.Telegram.NET.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Hangfire;
using Hangfire.PostgreSql;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Host;
using Laraue.Apps.LearnLanguage.Services;
using Laraue.Apps.LearnLanguage.Services.Jobs;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Apps.LearnLanguage.Services.Services;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.CefrLevel;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.Topic;
using Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Random;
using Laraue.Core.DateTime.Services.Abstractions;
using Laraue.Core.DateTime.Services.Impl;
using Laraue.Telegram.NET.Authentication.Services;
using Laraue.Telegram.NET.Core;
using Laraue.Telegram.NET.Core.Middleware;
using Laraue.Telegram.NET.Localization;
using Laraue.Telegram.NET.Localization.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<TelegramOptions>();
builder.Services.Configure<TelegramOptions>(builder.Configuration.GetSection("Telegram"));

builder.Services.AddOptions<TelegramNetOptions>();
builder.Services.Configure<TelegramNetOptions>(builder.Configuration.GetSection("Telegram"));

builder.Services
    .AddSingleton<IDateTimeProvider, DateTimeProvider>()
    .AddTelegramCore()
    .AddTelegramMiddleware<HandleExceptionsMiddleware>()
    .AddTelegramMiddleware<AutoCallbackResponseMiddleware>()
    .AddTelegramRequestLocalization<LocalizationProvider>()
    .Configure<TelegramRequestLocalizationOptions>(opt =>
    {
        opt.AvailableLanguages = InterfaceLanguage.Available.Select(x => x.Code).ToArray();
        opt.DefaultLanguage = InterfaceLanguage.Default.Code;
    })
    .AddTelegramAuthentication<User, Guid, RequestContext>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOptions<RoleUsers>();
builder.Services.Configure<RoleUsers>(builder.Configuration.GetSection("Telegram:Roles"));
builder.Services.UseUserRolesProvider<StaticUserRoleProvider>();

builder.Services
    .AddScoped<IMenuService, MenuService>()
    
    .AddScoped<IWordsRepository, WordsRepository>()
    .AddScoped<IWordsWindowFactory, WordsWindowFactory>()
    
    .AddScoped<IStatsRepository, StatsRepository>()
    .AddScoped<IAdminRepository, AdminRepository>()
    
    .AddScoped<IUserSettingsService, UserSettingsService>()
    .AddScoped<IUserRepository, UserRepository>()
    
    .AddScoped<ILearnRandomWordsService, LearnRandomWordsService>()
    .AddScoped<ILearnRandomWordsRepository, LearnRandomWordsRepository>()
    
    .AddScoped<ISelectLanguageService, SelectLanguageService>()
    
    .AddScoped<IStatsService, StatsService>()
    
    .AddScoped<ILearnByCefrLevelService, LearnByCefrLevelService>()
    .AddScoped<ILearnByFirstLetterService, LearnByFirstLetterService>()
    .AddScoped<ILearnByTopicService, LearnByTopicService>()
    .AddScoped<ILearnByCefrLevelRepository, LearnByCefrLevelRepository>()
    .AddScoped<ILearnByTopicRepository, LearnByTopicRepository>()
    .AddScoped<ILearnByFirstLetterRepository, LearnByFirstLetterRepository>();

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

using (var scope = app.Services.CreateScope())
{
    await using var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await db.Database.MigrateAsync();
    
    app.MapTelegramRequests();

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