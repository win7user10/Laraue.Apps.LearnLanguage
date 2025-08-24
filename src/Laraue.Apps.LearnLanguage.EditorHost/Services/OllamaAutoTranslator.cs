using System.Text.Json;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class OllamaAutoTranslator(HttpClient httpClient, ILogger<OllamaAutoTranslator> logger) : IAutoTranslator
{
    public async Task<TranslationResult> TranslateAsync(TranslationData translationData)
    {
        for (var i = 0; i < 3; i++)
        {
            try
            {
                return await TranslateInternalAsync(translationData);
            }
            // sometimes the model gallucinate and returns incorrect result
            catch (ArgumentException e)
            {
                logger.LogError(e, e.Message);
            }
            catch (JsonException e)
            {
                logger.LogError(e, e.Message);
            }
        }
        
        throw new InvalidOperationException();
    }

    private async Task<TranslationResult> TranslateInternalAsync(TranslationData translationData)
    {
        var prompt = @$"
Translate the word ""{translationData.Word}"" with part of speech ""{translationData.PartOfSpeech}"" to the languages '{string.Join(',', translationData.ToLanguages)}'.
Respond with JSON. Return no more than one translation for each language key.

```
{{
    ""transcription"": ""$Transliterated requested word. For example 'she' should become 'shi:'"",
    ""meaning"": ""$Meaning of requested word"",
    ""frequency"": ""$How frequent requested word appears in a text. Number from 1 to 10 where 1 means word never appears in text and 10 - always in text"",
    ""topics"": [""$Topic name of requested word""]
    ""translations"": [
        {{
            ""language"": ""$Language code"",
            ""text"": ""$Translation"",
            ""transcription"": ""$English transliteration of translation""
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
            throw new ArgumentException();
        }
        
        logger.LogInformation("Taken ollama response {Response}", result);

        var items = result.Translations
            .ToDictionary(x => x.Language, x => new TranslationResultItem
        {
            Transcription = x.Transcription,
            Translation = x.Text
        });

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