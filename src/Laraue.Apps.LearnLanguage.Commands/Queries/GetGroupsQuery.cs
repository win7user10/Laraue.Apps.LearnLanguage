using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetGroupsQuery : PaginatedRequest, IRequest<IPaginatedResult<GroupDto>>
{
    public string UserId { get; init; }
}

public record GroupDto(long SerialNumber, string FirstWord, int LearnedCount, int TotalCount);

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IPaginatedResult<GroupDto>>
{
    private readonly DatabaseContext _context;

    public GetGroupsQueryHandler(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IPaginatedResult<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _context.WordGroups
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.Id)
            .Select(x => new GroupDto(
                x.SerialNumber,
                x.WordGroupWords
                    .Select(x => x.WordTranslation.Word.Name)
                    .OrderBy(x => x)
                    .First(),
                x.WordGroupWords.Count(
                    y => y.WordTranslationState.LearnState.HasFlag(LearnState.Learned)),
                x.WordGroupWords.Count))
            .PaginateAsync(request, cancellationToken);
    }
}