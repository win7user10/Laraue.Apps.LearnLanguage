using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.EFCore.Extensions;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetGroupWordsQuery : PaginatedRequest, IRequest<IPaginatedResult<LearningItem>>
{
    public long Id { get; init; }
    public string UserId { get; init; }
    public ShowWordsMode ShowWordsMode { get; init; }
}

public record LearningItem(
    string Word,
    string Translation,
    long SerialNumber,
    LearnState LearnState,
    int ViewCount);

public class GetLearningBatchRequestHandler : IRequestHandler<GetGroupWordsQuery, IPaginatedResult<LearningItem>>
{
    private readonly DatabaseContext _context;

    public GetLearningBatchRequestHandler(DatabaseContext context)
    {
        _context = context;
    }
    
    public Task<IPaginatedResult<LearningItem>> Handle(GetGroupWordsQuery query, CancellationToken cancellationToken)
    {
        var dbQuery = _context.WordGroupWords
            .Where(x => x.WordGroup.SerialNumber == query.Id)
            .Where(x => x.WordGroup.UserId == query.UserId);

        if (query.ShowWordsMode.HasFlag(ShowWordsMode.Hard))
        {
            dbQuery = dbQuery.Where(x => x.WordTranslationState.LearnState.HasFlag(LearnState.Hard));
        }

        if (query.ShowWordsMode.HasFlag(ShowWordsMode.NotLearned))
        {
            dbQuery = dbQuery.Where(x => !x.WordTranslationState.LearnState.HasFlag(LearnState.Learned));
        }

        return dbQuery
            .OrderBy(x => x.SerialNumber)
            .Select(x => new LearningItem(
                x.WordTranslation.Word.Name,
                x.WordTranslation.Translation,
                x.SerialNumber,
                x.WordTranslationState.LearnState,
                x.WordTranslationState.ViewCount))
            .PaginateAsync(query, cancellationToken);
    }
}