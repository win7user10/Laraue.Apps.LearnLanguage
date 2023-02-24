using Laraue.Apps.LearnLanguage.Commands.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetGroupWordsQuery : PaginatedRequest, IRequest<IPaginatedResult<LearningItem>>
{
    public long Id { get; init; }
    public ShowWordsMode ShowWordsMode { get; init; }
}

public record LearningItem(
    string Word,
    string Translation,
    long SerialNumber,
    LearnState LearnState,
    int ViewCount,
    long TranslationId);

public class GetGroupWordsQueryHandler : IRequestHandler<GetGroupWordsQuery, IPaginatedResult<LearningItem>>
{
    private readonly DatabaseContext _context;

    public GetGroupWordsQueryHandler(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IPaginatedResult<LearningItem>> Handle(GetGroupWordsQuery query, CancellationToken cancellationToken)
    {
        var dbQuery = _context.WordGroupWords
            .Where(x => x.WordGroup.Id == query.Id)
            .OrderBy(x => x.SerialNumber)
            .QueryGroupWordsWithStates(
                _context,
                (word, state) => new
                {
                    Item = new LearningItem(
                        word.WordTranslation.Word.Name,
                        word.WordTranslation.Translation,
                        word.SerialNumber,
                        state.LearnState,
                        state.ViewCount,
                        word.WordTranslation.Id
                    ),
                    State = state,
                });

        if (query.ShowWordsMode.HasFlag(ShowWordsMode.Hard))
        {
            dbQuery = dbQuery.Where(x => x.State.LearnState.HasFlag(LearnState.Hard));
        }

        if (query.ShowWordsMode.HasFlag(ShowWordsMode.NotLearned))
        {
            dbQuery = dbQuery.Where(x => !x.State.LearnState.HasFlag(LearnState.Learned));
        }
        
        return await dbQuery
            .Select(x => x.Item)
            .PaginateAsync(query, cancellationToken);
    }
}