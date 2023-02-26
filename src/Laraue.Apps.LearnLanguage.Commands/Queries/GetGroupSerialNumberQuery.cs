using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetGroupSerialNumberQuery : IRequest<long>
{
    public long Id { get; init; }
}

public class GetGroupSerialNumberQueryHandler : IRequestHandler<GetGroupSerialNumberQuery, long>
{
    private readonly DatabaseContext _context;

    public GetGroupSerialNumberQueryHandler(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<long> Handle(GetGroupSerialNumberQuery query, CancellationToken cancellationToken)
    {
        return _context.WordGroups.Where(x => x.Id == query.Id)
            .Select(x => x.SerialNumber)
            .FirstOrThrowNotFoundAsync(cancellationToken);
    }
}