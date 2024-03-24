using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class GetWordsRequest : IPaginatedRequest
{
    public string? Search { get; init; }
    public int Page { get; init; }
    public int PerPage { get; init; }
}