﻿using System.Runtime.CompilerServices;
using System.Text.Json;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
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
            []));

        await UpdateJsonFileAsync();

        return MaxWordId;
    }

    public async Task<int> AddMeaningAsync(int wordId, MeaningDto meaningDto)
    {
        var word = GetWord(wordId);

        if (meaningDto.Meaning == string.Empty)
        {
            throw new BadRequestException(nameof(meaningDto.Meaning), "Empty meaning has been passed");
        }
        
        if (word.Meanings.Any(m => m.Meaning is not null && m.Meaning == meaningDto.Meaning))
        {
            throw new BadRequestException(nameof(meaningDto.Meaning), "The same meaning has been added already");
        }
        
        ValidateCefrLevel(meaningDto.CefrLevel);
        foreach (var topic in meaningDto.Topics)
        {
            ValidateTopic(topic);
        }

        var newMeaning = new ImportingMeaning(
            word.Meanings.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
            meaningDto.Meaning,
            meaningDto.CefrLevel,
            meaningDto.Topics,
            meaningDto.PartsOfSpeech,
            []);
        
        word.Meanings.Add(newMeaning);
        
        await UpdateJsonFileAsync();

        return newMeaning.Id;
    }

    public async Task<int> AddTranslationAsync(int wordId, int meaningId, TranslationDto translationDto)
    {
        var word = GetWord(wordId);
        var meaning = GetMeaning(word, meaningId);
        
        if (string.IsNullOrEmpty(translationDto.Text))
        {
            throw new BadRequestException(
                nameof(translationDto.Text),
                "Translation should be not null or empty");
        }
        
        if (meaning.Translations.Any(
            m => m.Language == translationDto.LanguageCode && m.Text == translationDto.Text))
        {
            throw new BadRequestException(
                nameof(translationDto.Text),
                "The same translation has been added already");
        }
        
        ValidateLanguageCode(translationDto.LanguageCode);

        if (translationDto.LanguageCode == word.Language)
        {
            throw new BadRequestException(
                nameof(translationDto.LanguageCode),
                "Attempt to add translation to the same language");
        }

        var newTranslation = new ImportingMeaningTranslation(
            meaning.Translations.Select(m => m.Id).DefaultIfEmpty().Max() + 1,
            translationDto.LanguageCode,
            translationDto.Text);
        
        meaning.Translations.Add(newTranslation);

        await UpdateJsonFileAsync();

        return newTranslation.Id;
    }

    private ImportingWord GetWord(int wordId)
    {
        var word = Words.FirstOrDefault(w => w.Id == wordId);
        if (word is null)
        {
            throw new BadRequestException(nameof(wordId), "The word with the passed identifier is not exists");
        }

        return word;
    }
    
    private ImportingMeaning GetMeaning(ImportingWord word, int meaningId)
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

    private static void ValidateLanguageCode(string languageCode, [CallerMemberName] string propertyName = "")
    {
        if (DefaultContextData.WordLanguages.All(l => l.Code != languageCode))
        {
            throw new BadRequestException(propertyName, "Unknown language code has been passed");
        }
    }
    
    private static void ValidateCefrLevel(string? cefrLevel, [CallerMemberName] string propertyName = "")
    {
        if (cefrLevel is null)
        {
            return;
        }
        
        if (DefaultContextData.CefrLevels.All(l => l.Name != cefrLevel))
        {
            throw new BadRequestException(propertyName, "Unknown CEFR level has been passed");
        }
    }
    
    private static void ValidateTopic(string topicName, [CallerMemberName] string propertyName = "")
    {
        if (DefaultContextData.WordTopics.All(l => l.Name != topicName))
        {
            throw new BadRequestException(propertyName, "Unknown topic has been passed");
        }
    }
}