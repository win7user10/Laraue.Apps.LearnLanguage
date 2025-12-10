using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group.CefrLevel;

public class LearnByCefrLevelRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<long>(context), ILearnByCefrLevelRepository
{
    private readonly DatabaseContext _context = context;

    public override async Task<IFullPaginatedResult<LearningItemGroup<long>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginatedRequest request,
        CancellationToken ct = default)
    {
        return await _context.Translations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId))
            .Where(x => x.Word.CefrLevelId != null)
            .GroupBy(x => new { WordCefrLevelId = x.Word.CefrLevelId, x.Word.CefrLevel!.Name })
            .OrderBy(x => x.Key.WordCefrLevelId)
            .Select((x, i) => new LearningItemGroup<long>(
                x.Key.WordCefrLevelId.GetValueOrDefault(),
                _context.LearnedTranslations
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.Translation.HasLanguage(
                            selectedTranslation.LanguageToLearnId)
                        && y.Word.CefrLevelId == x.Key.WordCefrLevelId),
                x.Count(),
                x.Key.Name))
            .FullPaginateLinq2DbAsync(request, ct);
    }

    public override Task<string> GetGroupNameAsync(long groupId, CancellationToken ct = default)
    {
        return _context.CefrLevels
            .Where(x => x.Id == groupId)
            .Select(x => x.Name)
            .FirstAsyncLinqToDB(ct);
    }

    protected override Expression<Func<Translation, bool>> GetGroupWordsFilter(long id)
    {
        return translation => translation.Word.CefrLevelId == id;
    }
}