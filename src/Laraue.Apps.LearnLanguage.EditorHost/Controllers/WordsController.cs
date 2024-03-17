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
}