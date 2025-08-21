// See https://aka.ms/new-console-template for more information

using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", optional: true)
    .Build();

Console.OutputEncoding = System.Text.Encoding.UTF8;

var serviceCollection = new ServiceCollection()
    .AddLogging(x => x.AddConsole())
    .AddSingleton<IWordsService, WordsService>()
    .AddSingleton<IConfiguration>(configuration);

serviceCollection.AddHttpClient<IAutoTranslator, OllamaAutoTranslator>(x =>
{
    x.BaseAddress = new Uri("http://localhost:11434/");
});

var services = serviceCollection.BuildServiceProvider();

var wordsService = services.GetRequiredService<IWordsService>();
var logger = services.GetRequiredService<ILogger<Program>>();
var autoTranslator = services.GetRequiredService<IAutoTranslator>();

var result = await wordsService.GetWordsAsync(new GetWordsRequest
{
    PerPage = 1_000_000,
    Page = 0
});

foreach (var word in result.Data)
{
    logger.LogInformation("See '{Word}'", word.Word);
    
    if (word.Meanings.Count != 1)
    {
        logger.LogInformation("Skip '{Word}' with more than one meaning", word.Word);
        
        continue;
    }

    var defaultMeaning = word.Meanings.Single();
    var existsTranslationLanguages = defaultMeaning.Translations
        .Where(t => !string.IsNullOrEmpty(t.Text))
        .Where(t => !string.IsNullOrEmpty(t.Transcription))
        .Select(t => t.Language);
    
    var allTranslationLanguages = DefaultContextData.WordLanguages
        .Items
        .Select(t => t.Name)
        .Except([word.Language]);

    var missingTranslationLanguages = allTranslationLanguages.Except(existsTranslationLanguages).ToArray();

    if (missingTranslationLanguages.Length > 0)
    {
        logger.LogInformation(
            "Try to translate '{Word}' to '[{Languages}]'",
            word.Word,
            string.Join(", ", missingTranslationLanguages));
        
        var translationResult = await autoTranslator.TranslateAsync(new TranslationData
        {
            FromLanguage = word.Language,
            ToLanguages = missingTranslationLanguages,
            Word = word.Word
        });

        foreach (var translationResultItem in translationResult.Items)
        {
            logger.LogInformation(
                "Update '{Word}' translation to '{Language}' to '{Value}' '({Transcription})'", 
                word.Word,
                translationResultItem.Key,
                translationResultItem.Value.Translation,
                translationResultItem.Value.Transcription);
            
            await wordsService.UpsertTranslationAsync(
                word.Id,
                defaultMeaning.Id, 
                new UpdateTranslationDto(
                    translationResultItem.Key,
                    translationResultItem.Value.Translation!,
                    translationResultItem.Value.Transcription));
        }
    }
}