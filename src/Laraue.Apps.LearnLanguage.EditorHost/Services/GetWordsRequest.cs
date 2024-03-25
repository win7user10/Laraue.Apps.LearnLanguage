using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public class GetWordsRequest : IPaginatedRequest
{
    public string? Search { get; init; }
    public string[] Topics { get; init; } = Array.Empty<string>();
    public int Page { get; init; }
    public int PerPage { get; init; }
}