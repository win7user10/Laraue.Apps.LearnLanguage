using Laraue.Apps.LearnLanguage.Common.Contracts;
using Laraue.Apps.LearnLanguage.EditorHost.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laraue.Apps.LearnLanguage.EditorHost.Controllers;

[ApiController]
[Route("[controller]")]
public class WordsController(IWordsService wordsService) : ControllerBase
{
    [HttpGet]
    public Task<IReadOnlyList<ImportingWord>> GetWordsAsync()
    {
        return wordsService.GetWordsAsync();
    }
    
    [HttpPost]
    public Task<int> AddWordAsync([FromBody] WordDto wordDto)
    {
        return wordsService.AddWordAsync(wordDto);
    }
    
    [HttpPost("{wordId:int}/Meaning")]
    public Task<int> AddMeaningAsync(int wordId, [FromBody] MeaningDto meaningDto)
    {
        return wordsService.AddMeaningAsync(wordId, meaningDto);
    }
    
    [HttpPost("{wordId:int}/Meaning/{meaningId:int}/Translation")]
    public Task<int> AddTranslationAsync(int wordId, int meaningId, [FromBody] TranslationDto translationDto)
    {
        return wordsService.AddTranslationAsync(wordId, meaningId, translationDto);
    }
}