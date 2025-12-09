using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.Ollama;
using Microsoft.Extensions.Logging;

namespace Laraue.Apps.LearnLanguage.AutoTranslator;

public interface IResxFilesTranslator
{
    Task TranslateFileAsync(string filePath, string fileName);
}

public class ResxFilesTranslator(IOllamaPredictor ollamaPredictor, ILogger<ResxFilesTranslator> logger) : IResxFilesTranslator
{
    public async Task TranslateFileAsync(string filePath, string fileName)
    {
        var mainFileContent = await File.ReadAllTextAsync(Path.Combine(filePath, $"{fileName}.resx"));
        
        var translationFilePaths = Directory.EnumerateFiles(
            filePath,
            $"{fileName}.*.resx",
            SearchOption.TopDirectoryOnly);

        var existsTranslationLanguages = translationFilePaths
            .Select(Path.GetFileNameWithoutExtension)
            .Select(i => i!.Split('.')[1])
            .ToArray();
        
        var allTranslationLanguages = DefaultContextData.WordLanguages
            .Items
            .Select(t => t.Name)
            .Except(["en"]);

        var missingTranslationLanguages = allTranslationLanguages
            .Except(existsTranslationLanguages)
            .ToArray();
        
        logger.LogInformation($"Missing translation language: {string.Join(", ", missingTranslationLanguages)}");
        
        foreach (var missingTranslationLanguage in missingTranslationLanguages)
        {
            logger.LogInformation($"Translate file to: '{missingTranslationLanguage}'");
            
            var prompt = $"Translate the resx file to '{missingTranslationLanguage}'. Return xml content with replaces language phrases in 'Result' property. The file content: {Environment.NewLine} {mainFileContent}";
            var result = await ollamaPredictor.PredictAsync<PredictionResult>(
                "gemma3:12b",
                prompt);

            var newFilePath = Path.Combine(filePath, $"{fileName}.{missingTranslationLanguage}.resx");

            await File.WriteAllTextAsync(newFilePath, result.Result);
        }
    }
}

public class PredictionResult
{
    public required string Result { get; set; }
}