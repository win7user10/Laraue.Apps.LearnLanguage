using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Extensions;
using Laraue.Core.Exceptions.Web;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class WordsService : IWordsService
{
    private readonly string _wordsJsonPath;
    
    private List<ImportingWord>? _wordsCache;
    private int? _maxWordId;

    private List<ImportingWord> Words
    {
        get
        {
            _wordsCache ??= DefaultContextData.Words.ToList() ?? [];
            return _wordsCache;
        }
    }

    private int MaxWordId
    {
        get => _maxWordId ??= Words.Max(w => w.Id);
        set => _maxWordId = value;
    }

    public WordsService(IConfiguration configuration, ILogger<WordsService> logger)
    {
        _wordsJsonPath = configuration["TranslationsFile"]
                         ?? throw new InvalidOperationException("'TranslationsFile' section is not set");
        
        logger.LogInformation("Write translations to '{TranslationsFile}'", _wordsJsonPath);
    }

    public Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync(GetWordsRequest request)
    {
        var wordsQuery = Words.AsEnumerable();
        if (!string.IsNullOrEmpty(request.Search))
        {
            wordsQuery = wordsQuery.Where(w => w.Word.StartsWith(request.Search));
        }
        
        return Task.FromResult(wordsQuery
            .OrderByDescending(w => w.Id)
            .ShortPaginate(request));
    }

    public async Task<long> UpsertWordAsync(UpdateWordDto wordDto)
    {
        DefaultContextData.CefrLevels.EnsureExists(wordDto.CefrLevel);

        if (wordDto.Id.HasValue)
        {
            var word = GetWord(wordDto.Id.Value);
            Populate(word, wordDto);

            await UpdateJsonFileAsync();
            return wordDto.Id.Value;
        }
        
        var newWord = new ImportingWord
        {
            Id = ++MaxWordId,
        };
            
        Populate(newWord, wordDto);
        Words.Add(newWord);
        
        await UpdateJsonFileAsync();
        return newWord.Id;
    }

    public async Task<long> UpsertTranslationAsync(long wordId, UpdateTranslationDto updateTranslationDto)
    {
        var word = GetWord(wordId);
        
        if (string.IsNullOrEmpty(updateTranslationDto.Text))
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Text),
                "Translation should be not null or empty");
        }

        DefaultContextData.WordLanguages.EnsureExists(updateTranslationDto.Language);
        if (word.Translations.Any(
            m => m.Language == updateTranslationDto.Language && m.Text == updateTranslationDto.Text))
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Text),
                "The same translation has been added already");
        }

        if (updateTranslationDto.Language == "en")
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Language),
                "Attempt to add translation to the same language");
        }
        
        if (TryGetTranslation(word, updateTranslationDto.Language, out var translation))
        {
            Populate(translation, updateTranslationDto);
            await UpdateJsonFileAsync();
            return translation.Id;
        }
        
        var newTranslation = new ImportingTranslation
        {
            Id = word.Translations.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
        };
        
        Populate(newTranslation, updateTranslationDto);
        word.Translations.Add(newTranslation);
        
        await UpdateJsonFileAsync();
        return newTranslation.Id;
    }

    public Task DeleteTranslationAsync(long wordId, string translationCode)
    {
        var word = GetWord(wordId);
        var translation = GetTranslation(word, translationCode);
        
        word.Translations.Remove(translation);
        
        return UpdateJsonFileAsync();
    }

    public Task DeleteWordAsync(long wordId)
    {
        var word = GetWord(wordId);
        Words.Remove(word);

        return UpdateJsonFileAsync();
    }

    private static void Populate(ImportingWord word, UpdateWordDto updateWordDto)
    {
        word.Transcription = updateWordDto.Transcription;
        word.CefrLevel = updateWordDto.CefrLevel;
        word.Word = updateWordDto.Word;
        word.PartOfSpeech = updateWordDto.PartOfSpeech;
        word.Topics = updateWordDto.Topics;
        word.Frequency = updateWordDto.Frequency;
        word.Meaning = updateWordDto.Meaning;
    }
    
    private static void Populate(ImportingTranslation translation, UpdateTranslationDto updateTranslationDto)
    {
        translation.Language = updateTranslationDto.Language;
        translation.Text = updateTranslationDto.Text;
        translation.Transcription = updateTranslationDto.Transcription;
    }

    private ImportingWord GetWord(long wordId)
    {
        var word = Words.FirstOrDefault(w => w.Id == wordId);
        if (word is null)
        {
            throw new BadRequestException(nameof(wordId), "The word with the passed identifier is not exists");
        }

        return word;
    }
    
    private static ImportingTranslation GetTranslation(ImportingWord word, string translationCode)
    {
        if (!TryGetTranslation(word, translationCode, out var translation))
        {
            throw new BadRequestException(nameof(translationCode), "The translation with the passed identifier is not exists");
        }

        return translation;
    }
    
    private static bool TryGetTranslation(
        ImportingWord word,
        string translationCode,
        [NotNullWhen(true)] out ImportingTranslation? translation)
    {
        translation = word.Translations.FirstOrDefault(m => m.Language == translationCode);
        return translation is not null;
    }

    private Task UpdateJsonFileAsync()
    {
        return File.WriteAllTextAsync(_wordsJsonPath, JsonSerializer.Serialize(Words, Constants.JsonWebOptions));
    }
}