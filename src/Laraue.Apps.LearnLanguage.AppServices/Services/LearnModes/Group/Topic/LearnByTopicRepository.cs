using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group.Topic;

public class LearnByTopicRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<long>(context), ILearnByTopicRepository
{
    private readonly DatabaseContext _context = context;

    public override async Task<FullPaginatedResult<LearningItemGroup<long>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginationData request,
        CancellationToken ct = default)
    {
        return await _context.WordTopics
            .Where(x => x.HasLanguage(
                selectedTranslation.LanguageToLearnId))
            .GroupBy(x => new { WordTopicId = x.TopicId, x.Topic.Name })
            .Select(group => new LearningItemGroup<long>(
                group.Key.WordTopicId,
                _context.LearnedTranslations
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.Translation.HasLanguage(
                            selectedTranslation.LanguageToLearnId)
                        && y.Translation.Word.Topics.Any(t => t.TopicId == group.Key.WordTopicId)),
                group.Count(),
                group.Key.Name))
            .OrderByDescending(x => x.TotalCount)
            .FullPaginateLinq2DbAsync(request, ct);
    }

    public override Task<string> GetGroupNameAsync(long groupId, CancellationToken ct = default)
    {
        return _context.Topics
            .Where(x => x.Id == groupId)
            .Select(x => x.Name)
            .FirstAsyncLinqToDB(ct);
    }

    protected override Expression<Func<Translation, bool>> GetGroupWordsFilter(long id)
    {
        return translation => translation.Word.Topics.Any(x => x.TopicId == id);
    }
}