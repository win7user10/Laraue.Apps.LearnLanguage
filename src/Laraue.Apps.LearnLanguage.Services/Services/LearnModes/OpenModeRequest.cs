using Laraue.Apps.LearnLanguage.Common;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Telegram.NET.Abstractions.Request;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public sealed record OpenModeRequest : WithSelectedTranslationRequest, IPaginatedRequest
{
    public OpenModeRequest()
    {
        Pagination = new PaginationData
        {
            Page = Page,
            PerPage = PerPage
        };
    }
    
    [FromQuery(ParameterNames.Page)]
    public int Page { get; init; }
    
    public int PerPage { get; init; } = 16;
    public PaginationData Pagination { get; init; }
}