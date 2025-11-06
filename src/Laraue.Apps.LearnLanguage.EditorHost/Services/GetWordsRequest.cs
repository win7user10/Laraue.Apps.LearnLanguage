using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class GetWordsRequest : IPaginatedRequest
{
    public GetWordsRequest()
    {
        Pagination = new PaginationData
        {
            Page = Page,
            PerPage = PerPage
        };
    }
    
    public string? Search { get; init; }
    public string[] Topics { get; init; } = [];
    public int Page { get; init; }
    public int PerPage { get; init; }
    
    public PaginationData Pagination { get; init; }
}