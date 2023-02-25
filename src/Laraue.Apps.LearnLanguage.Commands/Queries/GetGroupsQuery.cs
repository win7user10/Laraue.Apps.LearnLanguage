using Laraue.Apps.LearnLanguage.Commands.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Extensions;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetGroupsQuery : PaginatedRequest, IRequest<IPaginatedResult<GroupDto>>
{
    public string UserId { get; init; }
}

public record GroupDto(long Id, long SerialNumber, string FirstWord, int LearnedCount, int TotalCount);

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IPaginatedResult<GroupDto>>
{
    private readonly DatabaseContext _context;

    public GetGroupsQueryHandler(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IPaginatedResult<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.WordGroups
            .Where(x => x.UserId == request.UserId)
            .OrderBy(x => x.Id)
            .Select(x => new {
                x.SerialNumber,
                x.Id,
                FirstWord = x.WordGroupWords
                    .Select(y => y.WordTranslation.Word.Name)
                    .OrderBy(y => y)
                    .First(),
                x.WordGroupWords.Count})
            .PaginateAsync(request, cancellationToken);

        var groupIds = res.Data.Select(x => x.Id);
        var learnStat = await _context.WordGroupWords
            .QueryGroupWordsWithStates(_context, (word, state) => new { word.WordGroupId, state })
            .Where(x => groupIds.Contains(x.WordGroupId))
            .GroupBy(x => x.WordGroupId)
            .DisableGuard()
            .ToDictionaryAsyncLinqToDB(
                x => x.Key,
                x => x.Count(y => y.state?
                    .LearnState
                    .HasFlag(LearnState.Learned) ?? false),
                cancellationToken);

        return res.MapTo(x => new GroupDto(
            x.Id,
            x.SerialNumber,
            x.FirstWord,
            learnStat[x.Id],
            x.Count));
    }
}