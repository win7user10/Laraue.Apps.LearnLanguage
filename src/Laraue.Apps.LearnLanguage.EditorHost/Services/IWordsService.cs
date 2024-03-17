using Laraue.Apps.LearnLanguage.Common.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IWordsService
{
    Task<IReadOnlyList<ImportingWord>> GetWordsAsync();
    Task<int> AddWordAsync(WordDto wordDto);
    Task AddMeaningAsync(int wordId, MeaningDto meaningDto);
    Task AddTranslationAsync(int meaningId, TranslationDto translationDto);
}