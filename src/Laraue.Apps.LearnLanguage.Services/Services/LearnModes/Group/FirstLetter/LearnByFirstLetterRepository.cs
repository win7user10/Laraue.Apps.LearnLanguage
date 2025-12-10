using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;

public class LearnByFirstLetterRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<char>(context), ILearnByFirstLetterRepository
{
    public override async Task<IFullPaginatedResult<LearningItemGroup<char>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginatedRequest request,
        CancellationToken ct = default)
    {
        return await context.Translations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId))
            .GroupBy(x => x.Word.Text.Substring(0, 1).ToUpper())
            .OrderBy(x => x.Key)
            .Select((x, i) => new LearningItemGroup<char>(
                x.Key[0],
                context.LearnedTranslations
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.Translation.HasLanguage(
                            selectedTranslation.LanguageToLearnId)
                        && y.Translation.Word.Text.StartsWith(x.Key)),
                x.Count(),
                x.Key.ToUpper()))
            .FullPaginateLinq2DbAsync(request, ct);
    }

    public override Task<string> GetGroupNameAsync(char groupId, CancellationToken ct = default)
    {
        return Task.FromResult(groupId.ToString().ToUpper());
    }

    protected override Expression<Func<Translation, bool>> GetGroupWordsFilter(char id)
    {
        return translation => translation.Word.Text.StartsWith(
            id.ToString(),
            StringComparison.InvariantCultureIgnoreCase);
    }
}