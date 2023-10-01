using Laraue.Apps.LearnLanguage.Commands.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public record GetClosestUnlearnedGroupsQuery(long GroupId) : IRequest<ClosestUnlearnedGroups>;

public record ClosestUnlearnedGroups(long? PreviousGroupId, long? NextGroupId);

public sealed class GetClosestUnlearnedGroupsQueryHandler
    : IRequestHandler<GetClosestUnlearnedGroupsQuery, ClosestUnlearnedGroups>
{
    private readonly DatabaseContext _context;

    public GetClosestUnlearnedGroupsQueryHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ClosestUnlearnedGroups> Handle(
        GetClosestUnlearnedGroupsQuery request,
        CancellationToken cancellationToken)
    {
        var group = await _context.WordGroups
            .FirstAsync(x => x.Id == request.GroupId, cancellationToken);
        
        var notLearnedGroups = await _context.WordGroupWords
            .QueryGroupWordsWithStates(_context, (word, state) => new { word, state })
            .Where(x => x.word.WordGroup.UserId == group.UserId)
            .GroupBy(x => x.word.WordGroupId, (x, y) => new
            {
                NotAllLearned = y
                    .Any(y => y.state == null || (y.state.LearnState & LearnState.Learned) == 0),
                Key = x,
            })
            .Where(x => x.NotAllLearned)
            .Select(x => x.Key)
            .OrderBy(x => x)
            .ToListAsync(cancellationToken);

        var previousNotLearned = notLearnedGroups.LastOrDefault(x => x < group.Id);
        var nextNotLearned = notLearnedGroups.FirstOrDefault(x => x > group.Id);

        return new ClosestUnlearnedGroups(previousNotLearned, nextNotLearned);
    }
}