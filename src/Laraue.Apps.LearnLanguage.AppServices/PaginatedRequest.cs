using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.AppServices;

public record PaginatedRequest(int Page, int PerPage) : IPaginatedRequest
{
    public PaginationData Pagination { get; init; } = new() { Page = Page, PerPage = PerPage }; 
}