using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IWordsService
{
    Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync(GetWordsRequest request);
    Task<long> UpsertWordAsync(UpdateWordDto wordDto);
    Task<long> UpsertTranslationAsync(long wordId, UpdateTranslationDto updateTranslationDto);
    Task DeleteTranslationAsync(long wordId, string translationCode);
    Task DeleteWordAsync(long wordId);
}