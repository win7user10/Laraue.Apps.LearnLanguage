using System.Runtime.CompilerServices;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.Exceptions.Web;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class WordsService : IWordsService
{
    private readonly string _wordsJsonPath = DefaultContextData.GetJsonFilePath("translations.json");
    
    private List<ImportingWord>? _wordsCache;
    private int? _maxWordId;

    private List<ImportingWord> Words
    {
        get
        {
            _wordsCache ??= JsonSerializer.Deserialize<List<ImportingWord>>(_wordsJsonPath) ?? [];
            return _wordsCache;
        }
    }

    private int MaxWordId
    {
        get => _maxWordId ??= Words.Max(w => w.Id);
        set => _maxWordId = value;
    }

    public Task<IReadOnlyList<ImportingWord>> GetWordsAsync()
    {
        return Task.FromResult((IReadOnlyList<ImportingWord>) Words);
    }

    public async Task<int> AddWordAsync(WordDto wordDto)
    {
        if (Words.Any(w => w.Word == wordDto.Word))
        {
            throw new BadRequestException(nameof(wordDto.Word), "The same word has been added already");
        }
        
        ValidateLanguageCode(wordDto.LanguageCode);
        
        Words.Add(new ImportingWord(
            ++MaxWordId,
            wordDto.Word,
            wordDto.LanguageCode,
            wordDto.Transcription,
            Array.Empty<ImportingMeaning>()));

        await UpdateJsonFileAsync();

        return MaxWordId;
    }

    public Task AddMeaningAsync(int wordId, MeaningDto meaningDto)
    {
        throw new NotImplementedException();
    }

    public Task AddTranslationAsync(int meaningId, TranslationDto translationDto)
    {
        throw new NotImplementedException();
    }

    private Task UpdateJsonFileAsync()
    {
        return File.WriteAllTextAsync(_wordsJsonPath, JsonSerializer.Serialize(Words));
    }

    private void ValidateLanguageCode(string languageCode, [CallerMemberName] string propertyName = "")
    {
        if (DefaultContextData.WordLanguages.All(l => l.Code != languageCode))
        {
            throw new BadRequestException(propertyName, "Unknown language code has been passed");
        }
    }
}