using Laraue.Apps.LearnLanguage.Common.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IWordsService
{
    Task<IReadOnlyList<ImportingWord>> GetWordsAsync();
    Task<int> AddWordAsync(WordDto wordDto);
    Task<int> AddMeaningAsync(int wordId, MeaningDto meaningDto);
    Task<int> AddTranslationAsync(int wordId, int meaningId, TranslationDto translationDto);
}