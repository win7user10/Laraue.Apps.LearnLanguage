using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IWordsService
{
    Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync(GetWordsRequest request);
    Task<long> UpsertWordAsync(UpdateWordDto wordDto);
    Task<long> UpsertMeaningAsync(long wordId, UpdateMeaningDto updateMeaningDto);
    Task<long> UpsertTranslationAsync(long wordId, long meaningId, UpdateTranslationDto updateTranslationDto);
    Task DeleteTranslationAsync(long wordId, long meaningId, string translationCode);
}