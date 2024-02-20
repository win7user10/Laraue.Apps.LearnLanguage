using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.CefrLevel;

public class LearnByCefrLevelRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<long>(context), ILearnByCefrLevelRepository
{
    private readonly DatabaseContext _context = context;

    public override async Task<IList<LearningItemGroup<long>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        return await _context.WordTranslations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId))
            .Where(x => x.WordMeaning.WordCefrLevelId != null)
            .GroupBy(x => new { x.WordMeaning.WordCefrLevelId, x.WordMeaning.WordCefrLevel!.Name })
            .OrderBy(x => x.Key.WordCefrLevelId)
            .Select((x, i) => new LearningItemGroup<long>(
                x.Key.WordCefrLevelId.GetValueOrDefault(),
                _context.WordTranslationStates
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.WordTranslation.HasLanguage(
                            selectedTranslation.LanguageToLearnId,
                            selectedTranslation.LanguageToLearnFromId)
                        && y.WordTranslation.WordMeaning.WordCefrLevelId == x.Key.WordCefrLevelId),
                x.Count(),
                x.Key.Name))
            .ToListAsyncLinqToDB(ct);
    }

    public override Task<string> GetGroupNameAsync(long groupId, CancellationToken ct = default)
    {
        return _context.WordCefrLevels
            .Where(x => x.Id == groupId)
            .Select(x => x.Name)
            .FirstAsyncLinqToDB(ct);
    }

    protected override Expression<Func<WordTranslation, bool>> GetGroupWordsFilter(long id)
    {
        return translation => translation.WordMeaning.WordCefrLevelId == id;
    }
}