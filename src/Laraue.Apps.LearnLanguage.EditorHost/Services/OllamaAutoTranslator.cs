using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class OllamaAutoTranslator(HttpClient httpClient, ILogger<OllamaAutoTranslator> logger) : IAutoTranslator
{
    public async Task<TranslationResult> TranslateAsync(TranslationData translationData)
    {
        var prompt = @$"
Translate the word ""{translationData.Word}"" with part of speech ""{translationData.PartOfSpeech}"" to the languages '{string.Join(',', translationData.ToLanguages)}'.
Respond with JSON

```
{{
    ""transcription"": ""$Transliterated requested word. For example 'she' should become 'shi:'"",
    ""meaning"": ""$Meaning of the requested word"",
    ""frequency"": ""$How frequent the requested word appears in a text. The number from 1 to 10"",
    ""topics"": [""$Topic name of the requested word""]
    ""translations"": [
        {{
            ""language"": ""$Language code"",
            ""text"": ""$The translation"",
            ""transcription"": ""$English transliteration of the translation""
        }}
    ]
}}
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
                    Type = "object",
                    Properties = new
                    {
                        Transcription = new
                        {
                            Type = "string",
                        },
                        Meaning = new
                        {
                            Type = "string",
                        },
                        Frequency = new
                        {
                            Type = "number",
                        },
                        Topics = new
                        {
                            Type = "array",
                            Items = new
                            {
                                Type = "string",
                            }
                        },
                        Translations = new
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
                    }
                }
            },
            JsonSerializerOptions.Web);

        var ollamaResult = await response.Content.ReadFromJsonAsync<OllamaResult>(JsonSerializerOptions.Web);
        var result = JsonSerializer.Deserialize<Word>(ollamaResult!.Response, JsonSerializerOptions.Web);

        if (result is null)
        {
            throw new InvalidOperationException();
        }
        
        logger.LogInformation("Taken ollama response {Response}", result);

        var items = result.Translations
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
            Items = items,
            Transcription = result.Transcription,
            Topics = result.Topics,
            Meaning = result.Meaning,
            Frequency = result.Frequency,
        };
    }

    private class OllamaResult
    {
        public required string Response { get; set; }
    }

    private class Word
    {
        public required string Transcription { get; set; }
        public required string Meaning { get; set; }
        public required int Frequency { get; set; }
        public required string[] Topics { get; set; }
        public required Translation[] Translations { get; set; }
    }
    
    private class Translation
    {
        public required string Language { get; set; }
        public required string Transcription { get; set; }
        public required string Text { get; set; }
    }
}