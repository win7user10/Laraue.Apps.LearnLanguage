using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Laraue.Core.DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Laraue.Apps.LearnLanguage.EditorHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController(IWordsService wordsService) : ControllerBase
{
    [HttpGet]
    public Task<IShortPaginatedResult<ImportingWord>> GetWordsAsync([FromQuery] GetWordsRequest request)
    {
        return wordsService.GetWordsAsync(request);
    }
    
    [HttpPost]
    public Task<long> UpsertWordAsync([FromBody] UpdateWordDto wordDto)
    {
        return wordsService.UpsertWordAsync(wordDto);
    }
    
    [HttpPost("{wordId:int}/Meanings")]
    public Task<long> UpsertMeaningAsync(int wordId, [FromBody] UpdateMeaningDto updateMeaningDto)
    {
        return wordsService.UpsertMeaningAsync(wordId, updateMeaningDto);
    }
    
    [HttpPost("{wordId:int}/Meanings/{meaningId:int}/Translations")]
    public Task<long> UpsertTranslationAsync(int wordId, int meaningId, [FromBody] UpdateTranslationDto updateTranslationDto)
    {
        return wordsService.UpsertTranslationAsync(wordId, meaningId, updateTranslationDto);
    }
    
    [HttpDelete("{wordId:int}/Meanings/{meaningId:int}/Translations/{translationCode}")]
    public Task DeleteTranslationAsync(int wordId, int meaningId, string translationCode)
    {
        return wordsService.DeleteTranslationAsync(wordId, meaningId, translationCode);
    }
    
    [HttpDelete("{wordId:int}/Meanings/{meaningId:int}")]
    public Task DeleteMeaningAsync(int wordId, int meaningId)
    {
        return wordsService.DeleteMeaningAsync(wordId, meaningId);
    }
    
    [HttpDelete("{wordId:int}")]
    public Task DeleteWordAsync(int wordId)
    {
        return wordsService.DeleteWordAsync(wordId);
    }
}