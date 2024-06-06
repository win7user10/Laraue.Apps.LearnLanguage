// See https://aka.ms/new-console-template for more information

using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Crawling.Dynamic.PuppeterSharp.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PuppeteerSharp;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var loggerFactory = LoggerFactory.Create(builder => builder
    .AddConsole());

var logger = loggerFactory.CreateLogger<Program>();

var wordsService = new WordsService(configuration);
var autoTranslator = new YandexAutoTranslator(
    loggerFactory,
    new BrowserFactory(new LaunchOptions(), loggerFactory));

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
        .Select(t => t.Language);
    
    var allTranslationLanguages = DefaultContextData.WordLanguages
        .Items
        .Select(t => t.Name)
        .Except(new [] { word.Language });

    var missingTranslationLanguages = allTranslationLanguages.Except(existsTranslationLanguages).ToArray();

    if (missingTranslationLanguages.Length > 0)
    {
        logger.LogInformation(
            "Try to translate '{Word}' to [{Languages}]",
            word.Word,
            string.Join(", ", missingTranslationLanguages));
        
        var translationResult = await autoTranslator.TranslateAsync(new TranslationData
        {
            FromLanguage = word.Language,
            ToLanguages = missingTranslationLanguages,
            Word = word.Word
        });

        if (translationResult.Transcription is not null && word.Transcription is null)
        {
            logger.LogInformation(
                "Update '{Word}' transcription to {Transcription}",
                word.Word,
                translationResult.Transcription);
            
            await wordsService.UpsertWordAsync(new UpdateWordDto
            {
                Language = word.Language,
                Word = word.Word,
                Id = word.Id,
                Transcription = translationResult.Transcription
            });
        }

        foreach (var translationResultItem in translationResult.Items)
        {
            logger.LogInformation(
                "Update {Word} translation to {Language} to {Value}", 
                word.Word,
                translationResultItem.Key,
                translationResultItem.Value.Translation);
            
            await wordsService.UpsertTranslationAsync(
                word.Id,
                defaultMeaning.Id, 
                new UpdateTranslationDto(
                    translationResultItem.Key,
                    translationResultItem.Value.Translation!));
        }
    }
}