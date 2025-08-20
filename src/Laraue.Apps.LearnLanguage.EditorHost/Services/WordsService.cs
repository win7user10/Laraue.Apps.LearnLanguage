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

        if (request.Topics.Length != 0)
        {
            wordsQuery = wordsQuery
                .Where(w => w.Meanings
                    .Any(m => m.Topics.Any(request.Topics.Contains)));
        }
        
        return Task.FromResult(wordsQuery
            .OrderByDescending(w => w.Id)
            .ShortPaginate(request));
    }

    public async Task<long> UpsertWordAsync(UpdateWordDto wordDto)
    {
        DefaultContextData.WordLanguages.EnsureExists(wordDto.Language);
        
        if (Words.Any(w => w.Language == wordDto.Language && w.Word == wordDto.Word && w.Id != wordDto.Id))
        {
            throw new BadRequestException(nameof(wordDto.Word), "The same word has been added already");
        }

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

    public async Task<long> UpsertMeaningAsync(long wordId, UpdateMeaningDto updateMeaningDto)
    {
        var word = GetWord(wordId);
        
        if (word.Meanings.Any(
            m => m.Meaning is not null
                && m.Meaning == updateMeaningDto.Meaning
                && m.Id != updateMeaningDto.Id))
        {
            throw new BadRequestException(nameof(updateMeaningDto.Meaning), "The same meaning has been added already");
        }

        if (updateMeaningDto.Level != null)
        {
            DefaultContextData.CefrLevels.EnsureExists(updateMeaningDto.Level);
        }

        foreach (var topic in updateMeaningDto.Topics)
        {
            DefaultContextData.WordTopics.EnsureExists(topic);
        }
        
        foreach (var partOfSpeech in updateMeaningDto.PartsOfSpeech)
        {
            DefaultContextData.PartOfSpeeches.EnsureExists(partOfSpeech);
        }

        if (updateMeaningDto.Id.HasValue)
        {
            var meaning = GetMeaning(word, updateMeaningDto.Id.Value);
            Populate(meaning, updateMeaningDto);
            await UpdateJsonFileAsync();
            return updateMeaningDto.Id.Value;
        }
        
        var newMeaning = new ImportingMeaning
        {
            Id = word.Meanings.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
        };
        
        Populate(newMeaning, updateMeaningDto);
        word.Meanings.Add(newMeaning);
        
        await UpdateJsonFileAsync();
        return newMeaning.Id;
    }

    public async Task<long> UpsertTranslationAsync(long wordId, long meaningId, UpdateTranslationDto updateTranslationDto)
    {
        var word = GetWord(wordId);
        var meaning = GetMeaning(word, meaningId);
        
        if (string.IsNullOrEmpty(updateTranslationDto.Text))
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Text),
                "Translation should be not null or empty");
        }

        DefaultContextData.WordLanguages.EnsureExists(updateTranslationDto.Language);
        if (meaning.Translations.Any(
            m => m.Language == updateTranslationDto.Language && m.Text == updateTranslationDto.Text))
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Text),
                "The same translation has been added already");
        }

        if (updateTranslationDto.Language == word.Language)
        {
            throw new BadRequestException(
                nameof(updateTranslationDto.Language),
                "Attempt to add translation to the same language");
        }
        
        if (TryGetTranslation(meaning, updateTranslationDto.Language, out var translation))
        {
            Populate(translation, updateTranslationDto);
            await UpdateJsonFileAsync();
            return translation.Id;
        }
        
        var newTranslation = new ImportingMeaningTranslation
        {
            Id = meaning.Translations.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
        };
        
        Populate(newTranslation, updateTranslationDto);
        meaning.Translations.Add(newTranslation);
        
        await UpdateJsonFileAsync();
        return newTranslation.Id;
    }

    public Task DeleteTranslationAsync(long wordId, long meaningId, string translationCode)
    {
        var word = GetWord(wordId);
        var meaning = GetMeaning(word, meaningId);
        var translation = GetTranslation(meaning, translationCode);
        
        meaning.Translations.Remove(translation);
        
        return UpdateJsonFileAsync();
    }

    public Task DeleteMeaningAsync(long wordId, long meaningId)
    {
        var word = GetWord(wordId);
        var meaning = GetMeaning(word, meaningId);

        word.Meanings.Remove(meaning);
        
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
        word.Language = updateWordDto.Language;
        word.Word = updateWordDto.Word;
    }

    private static void Populate(ImportingMeaning meaning, UpdateMeaningDto updateMeaningDto)
    {
        meaning.Meaning = updateMeaningDto.Meaning;
        meaning.Topics = updateMeaningDto.Topics;
        meaning.PartsOfSpeech = updateMeaningDto.PartsOfSpeech;
        meaning.Level = updateMeaningDto.Level;
    }
    
    private static void Populate(ImportingMeaningTranslation translation, UpdateTranslationDto updateTranslationDto)
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
    
    private static ImportingMeaning GetMeaning(ImportingWord word, long meaningId)
    {
        var meaning = word.Meanings.FirstOrDefault(m => m.Id == meaningId);
        if (meaning is null)
        {
            throw new BadRequestException(nameof(meaningId), "The meaning with the passed identifier is not exists");
        }

        return meaning;
    }
    
    private static ImportingMeaningTranslation GetTranslation(ImportingMeaning meaning, string translationCode)
    {
        if (!TryGetTranslation(meaning, translationCode, out var translation))
        {
            throw new BadRequestException(nameof(translationCode), "The translation with the passed identifier is not exists");
        }

        return translation;
    }
    
    private static bool TryGetTranslation(
        ImportingMeaning meaning,
        string translationCode,
        [NotNullWhen(true)] out ImportingMeaningTranslation? translation)
    {
        translation = meaning.Translations.FirstOrDefault(m => m.Language == translationCode);
        return translation is not null;
    }

    private Task UpdateJsonFileAsync()
    {
        return File.WriteAllTextAsync(_wordsJsonPath, JsonSerializer.Serialize(Words, Constants.JsonWebOptions));
    }
}