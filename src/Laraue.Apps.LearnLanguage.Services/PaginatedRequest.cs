using Laraue.Core.DataAccess.Contracts;

namespace Laraue.Apps.LearnLanguage.Services;

public record PaginatedRequest(int Page, int PerPage) : IPaginatedRequest;