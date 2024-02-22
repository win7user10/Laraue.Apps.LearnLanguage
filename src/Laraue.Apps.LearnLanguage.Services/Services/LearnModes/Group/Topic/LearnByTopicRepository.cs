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

    public override async Task<IList<LearningItemGroup<long>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        return await _context.WordMeaningTopics
            .Where(x => x.HasLanguage(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId))
            .GroupBy(x => new { x.WordTopicId, x.WordTopic.Name })
            .Select(group => new LearningItemGroup<long>(
                group.Key.WordTopicId,
                _context.WordTranslationStates
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.WordTranslation.HasLanguage(
                            selectedTranslation.LanguageToLearnId,
                            selectedTranslation.LanguageToLearnFromId)
                        && y.WordTranslation.WordMeaning.Topics.Any(t => t.WordTopicId == group.Key.WordTopicId)),
                group.Count(),
                group.Key.Name))
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
        return translation => translation.WordMeaning.Topics.Any(x => x.WordTopicId == id);
    }
}