using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Core.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IWordsService, WordsService>();
builder.Services.AddScoped<ExceptionHandleMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandleMiddleware>();
app.MapControllers();

app.Run();