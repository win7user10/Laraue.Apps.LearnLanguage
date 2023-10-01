using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Core.DateTime.Services.Abstractions;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public record GetYesterdayUsersLearnStateQuery : IRequest<IList<UserDailyStat>>;

public sealed record UserDailyStat(
    long TelegramId,
    int LearnedYesterdayCount,
    int LearnedTotalCount,
    int TotalWordsCount);

public sealed class GetDailyUsersLearnStateQueryHandler : IRequestHandler<GetYesterdayUsersLearnStateQuery, IList<UserDailyStat>>
{
    private readonly DatabaseContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;

    public GetDailyUsersLearnStateQueryHandler(
        DatabaseContext dbContext,
        IDateTimeProvider dateTimeProvider)
    {
        _dbContext = dbContext;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<IList<UserDailyStat>> Handle(GetYesterdayUsersLearnStateQuery request, CancellationToken cancellationToken)
    {
        var yesterdayDate = _dateTimeProvider.UtcNow.AddDays(-1).Date;
        
        return await _dbContext
            .Users
            .Where(x => x.WordTranslationStates
                .Any(y => y.LearnedAt.HasValue
                          && y.LearnedAt.Value.Date == yesterdayDate))
            .Select(x => new UserDailyStat
            (
                x.TelegramId!.Value,
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue
                                && y.LearnedAt.Value.Date == yesterdayDate),
                x.WordTranslationStates
                    .Count(y => y.LearnedAt.HasValue),
                x.WordGroups.Sum(y => y.WordGroupWords.Count)
            ))
            .ToListAsyncLinqToDB(cancellationToken);
    }
}