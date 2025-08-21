using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class OllamaAutoTranslator(HttpClient httpClient) : IAutoTranslator
{
    public async Task<TranslationResult> TranslateAsync(TranslationData translationData)
    {
        var prompt = @$"
Translate the word ""{translationData.Word}"" to the languages '{string.Join(',', translationData.ToLanguages)}'
Respond with JSON

```
[
  {{
    ""language"": ""$language_code"",
    ""text"": ""$translation"",
    ""transcription"": ""$transcription""
  }}
]
```
";

        var response = await httpClient.PostAsJsonAsync(
            "api/generate", 
            new
            {
                Model = "gemma3:12b",
                Prompt = prompt,
                Stream = false,
                Format = new
                {
                    Type = "array",
                    Items = new
                    {
                        Type = "object",
                        Properties = new
                        {
                            Language = new
                            {
                                Type = "string",
                            },
                            Text = new
                            {
                                Type = "string",
                            },
                            Transcription = new
                            {
                                Type = "string",
                            }
                        }
                    }
                }
            },
            JsonSerializerOptions.Web);

        var ollamaResult = await response.Content.ReadFromJsonAsync<OllamaResult>(JsonSerializerOptions.Web);
        var result = JsonSerializer.Deserialize<Translation[]>(ollamaResult!.Response, JsonSerializerOptions.Web);

        if (result is null)
        {
            throw new InvalidOperationException();
        }

        var items = result
            .ToDictionary(x => x.Language, x => new TranslationResultItem
        {
            Transcription = x.Transcription,
            Translation = x.Text
        });

        if (!items.Keys.SequenceEqual(translationData.ToLanguages))
        {
            throw new InvalidOperationException($"Requested {string.Join(',', translationData.ToLanguages)}, got {string.Join(',', items.Keys)}");
        }

        return new TranslationResult
        {
            Items = items
        };
    }

    private class OllamaResult
    {
        public required string Response { get; set; }
    }

    private class Translation
    {
        public required string Language { get; set; }
        public required string Transcription { get; set; }
        public required string Text { get; set; }
    }
}