using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Core.Exceptions;
using Laraue.Crawling.Dynamic.PuppeterSharp.Utils;
using PuppeteerSharp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IWordsService, WordsService>();
builder.Services.AddSingleton<IDictionariesService, DictionariesService>();
builder.Services.AddScoped<ExceptionHandleMiddleware>();

builder.Services.AddSingleton<IBrowserFactory, BrowserFactory>();
builder.Services.AddSingleton<IAutoTranslator, GoogleAutoTranslator>();
builder.Services.AddSingleton(new LaunchOptions { Headless = true });

var app = builder.Build();

var origins = builder
    .Configuration
    .GetRequiredSection("Cors:Hosts")
    .Get<string[]>();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.WithOrigins(origins)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandleMiddleware>();
app.MapControllers();

app.Run();