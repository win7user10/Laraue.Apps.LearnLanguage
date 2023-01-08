using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using Laraue.Core.Exceptions;
using Laraue.LearnLanguage.DataAccess;
using Laraue.Telegram.NET.Authentication.Extensions;
using Laraue.Telegram.NET.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<ExceptionHandleMiddleware>()
    .AddMediatR(typeof(GetGroupWordsQuery))
    .AddTelegramCore(new TelegramBotClientOptions(builder.Configuration["Telegram:Token"]))
    .AddTelegramAuthentication<User>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services
    .AddDbContext<DatabaseContext>(opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgre"))
            .UseSnakeCaseNamingConvention();
    })
    .AddLinq2Db();

var app = builder.Build();

app.UseMiddleware<ExceptionHandleMiddleware>();
app.Services.UseLinq2Db();

app.MapTelegramRequests(builder.Configuration["Telegram:WebhookUrl"]);

using (var scope = app.Services.CreateScope())
{
    await using var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    await db.Database.MigrateAsync();
}

app.Run();