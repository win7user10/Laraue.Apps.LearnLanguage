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

    public WordsService(IConfiguration configuration)
    {
        _wordsJsonPath = configuration["TranslationsFile"]
            ?? throw new InvalidOperationException("'TranslationsFile' section is not set");
    }

    public Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync(GetWordsRequest request)
    {
        var wordsQuery = Words.AsEnumerable();
        if (!string.IsNullOrEmpty(request.Search))
        {
            wordsQuery = wordsQuery.Where(w => w.Word.StartsWith(request.Search));
        }
        
        return Task.FromResult(wordsQuery
            .ShortPaginate(request));
    }

    public async Task<long> UpsertWordAsync(UpdateWordDto wordDto)
    {
        DefaultContextData.WordLanguages.EnsureExists(wordDto.Language);
        
        if (Words.Any(w => w.Language == wordDto.Language && w.Word == wordDto.Language && w.Id != wordDto.Id))
        {
            throw new BadRequestException(nameof(wordDto.Word), "The same word has been added already");
        }

        if (!wordDto.Id.HasValue)
        {
            Words.Add(new ImportingWord
            {
                Id = ++MaxWordId,
                Transcription = wordDto.Transcription,
                Meanings = [],
                Language = wordDto.Language,
                Word = wordDto.Word,
            });
            
            return MaxWordId;
        }

        var word = GetWord(wordDto.Id.Value);
        word.Word = wordDto.Word;
        word.Language = wordDto.Language;
        word.Transcription = wordDto.Transcription;

        await UpdateJsonFileAsync();

        return wordDto.Id.Value;
    }

    public async Task<long> UpsertMeaningAsync(long wordId, UpdateMeaningDto updateMeaningDto)
    {
        var word = GetWord(wordId);

        if (updateMeaningDto.Meaning == string.Empty)
        {
            throw new BadRequestException(nameof(updateMeaningDto.Meaning), "Empty meaning has been passed");
        }
        
        if (word.Meanings.Any(m => m.Meaning is not null && m.Meaning == updateMeaningDto.Meaning))
        {
            throw new BadRequestException(nameof(updateMeaningDto.Meaning), "The same meaning has been added already");
        }
        
        var cefrLevelId = updateMeaningDto.CefrLevelId.HasValue
            ? DefaultContextData.CefrLevels.GetName(updateMeaningDto.CefrLevelId.Value)
            : null;

        foreach (var topic in updateMeaningDto.Topics)
        {
            DefaultContextData.WordTopics.EnsureExists(topic);
        }
        
        foreach (var partOfSpeech in updateMeaningDto.PartsOfSpeech)
        {
            DefaultContextData.PartOfSpeeches.EnsureExists(partOfSpeech);
        }
        
        var newMeaning = new ImportingMeaning(
            word.Meanings.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
            updateMeaningDto.Meaning,
            cefrLevelId,
            updateMeaningDto.Topics,
            updateMeaningDto.PartsOfSpeech,
            []);
        
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

        var newTranslation = new ImportingMeaningTranslation(
            meaning.Translations.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
            updateTranslationDto.Language,
            updateTranslationDto.Text);
        
        meaning.Translations.Add(newTranslation);

        await UpdateJsonFileAsync();

        return newTranslation.Id;
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
    
    private ImportingMeaning GetMeaning(ImportingWord word, long meaningId)
    {
        var meaning = word.Meanings.FirstOrDefault(m => m.Id == meaningId);
        if (meaning is null)
        {
            throw new BadRequestException(nameof(meaningId), "The meaning with the passed identifier is not exists");
        }

        return meaning;
    }

    private Task UpdateJsonFileAsync()
    {
        return File.WriteAllTextAsync(_wordsJsonPath, JsonSerializer.Serialize(Words, Constants.JsonWebOptions));
    }
}