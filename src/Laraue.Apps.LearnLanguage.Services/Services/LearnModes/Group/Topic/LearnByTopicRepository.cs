using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.Topic;

public class LearnByTopicRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<long>(context), ILearnByTopicRepository
{
    private readonly DatabaseContext _context = context;

    public override async Task<IList<LearningItemGroup<long>>> GetGroupsAsync(Guid userId, CancellationToken ct = default)
    {
        return await _context.WordTranslations
            .Where(x => x.Word.WordTopicId != null)
            .GroupBy(x => new { x.Word.WordTopicId, x.Word.WordTopic!.Name })
            .OrderBy(x => x.Key.Name)
            .Select((x, i) => new LearningItemGroup<long>(
                x.Key.WordTopicId.GetValueOrDefault(),
                _context.WordTranslationStates
                    .Count(y => y.UserId == userId
                                && y.WordTranslation.Word.WordTopicId == x.Key.WordTopicId),
                x.Count(),
                x.Key.Name))
            .ToListAsyncLinqToDB(ct);
    }

    public override Task<string> GetGroupNameAsync(long groupId, CancellationToken ct = default)
    {
        return _context.WordTopics
            .Where(x => x.Id == groupId)
            .Select(x => x.Name)
            .FirstAsyncLinqToDB(ct);
    }

    protected override Expression<Func<WordTranslation, bool>> GetGroupWordsFilter(long id)
    {
        return translation => translation.Word.WordTopicId == id;
    }
}