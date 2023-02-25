using Laraue.Apps.LearnLanguage.Commands.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public record GetLearnStateQuery(string UserId) : IRequest<GetLearnStateQueryResponse>;

public record GetLearnStateQueryResponse(TotalStat TotalStat, ICollection<DayLearnState> DaysStat);

public record TotalStat(int LearnedCount, int TotalCount, double? LearnSpeed, DateOnly? ApproximateLearnDate);

public record DayLearnState(DateTime Date, int LearnedCount);

public class GetLearnStateQueryHandler : IRequestHandler<GetLearnStateQuery, GetLearnStateQueryResponse>
{
    private readonly DatabaseContext _context;

    public GetLearnStateQueryHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetLearnStateQueryResponse> Handle(GetLearnStateQuery request, CancellationToken cancellationToken)
    {
        var getUserWordsQuery = _context.WordGroupWords
            .Where(x => x.WordGroup.UserId == request.UserId)
            .QueryGroupWordsWithStates(_context, (word, state) => new
            {
                state.LearnState,
                state.LearnedAt,
            });
        
        var wordsCount = await getUserWordsQuery.CountAsync(cancellationToken);
        
        var learnedCount = await getUserWordsQuery
            .Where(x => (x.LearnState & LearnState.Learned) != 0)
            .CountAsync(cancellationToken);

        var firstLearnedAt = await getUserWordsQuery
            .OrderBy(x => x.LearnedAt)
            .Select(x => x.LearnedAt)
            .FirstAsync(cancellationToken);

        double? learnSpeed = null;
        DateOnly? approximateLearnWordsDate = null;
        if (firstLearnedAt is not null)
        {
            var learnDays = (DateTimeOffset.UtcNow - firstLearnedAt).Value.TotalDays;
            learnSpeed = learnedCount / learnDays;

            var daysToLearn = (int)Math.Ceiling((wordsCount - learnedCount) / learnSpeed.Value);
            approximateLearnWordsDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(daysToLearn));
        }

        var totalStat = new TotalStat(learnedCount, wordsCount, learnSpeed, approximateLearnWordsDate);

        var daysStat = await getUserWordsQuery
            .Where(x => x.LearnedAt != null)
            .GroupBy(x => x.LearnedAt!.Value.Date)
            .OrderByDescending(x => x.Key)
            .Select(x => new DayLearnState(x.Key, x.Count()))
            .Take(10)
            .ToListAsync(cancellationToken);

        return new GetLearnStateQueryResponse(totalStat, daysStat);
    }
}