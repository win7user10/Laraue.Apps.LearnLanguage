using Laraue.Apps.LearnLanguage.DataAccess;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public record GetCurrentStateQuery(string UserId) : IRequest<CurrentState>;

public record CurrentState(bool AreGroupsFormed);

public class GetCurrentStateQueryHandler : IRequestHandler<GetCurrentStateQuery, CurrentState>
{
    private readonly DatabaseContext _context;

    public GetCurrentStateQueryHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CurrentState> Handle(GetCurrentStateQuery request, CancellationToken cancellationToken)
    {
        return new CurrentState(
            await _context.WordGroups
                .Where(x => x.UserId == request.UserId)
                .AnyAsyncLinqToDB(cancellationToken));
    }
}