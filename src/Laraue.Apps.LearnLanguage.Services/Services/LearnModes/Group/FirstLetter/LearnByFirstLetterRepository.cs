using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;

public class LearnByFirstLetterRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<char>(context), ILearnByFirstLetterRepository
{
    public override async Task<IList<LearningItemGroup<char>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        return await context.Translations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId))
            .GroupBy(x => x.Meaning.Word.Text.Substring(0, 1))
            .OrderBy(x => x.Key)
            .Select((x, i) => new LearningItemGroup<char>(
                x.Key[0],
                context.TranslationStates
                    .Learned()
                    .Count(y => y.UserId == userId
                        && y.Translation.HasLanguage(
                            selectedTranslation.LanguageToLearnId,
                            selectedTranslation.LanguageToLearnFromId)
                        && y.Translation.Meaning.Word.Text.StartsWith(x.Key)),
                x.Count(),
                x.Key.ToUpper()))
            .ToListAsyncLinqToDB(ct);
    }

    public override Task<string> GetGroupNameAsync(char groupId, CancellationToken ct = default)
    {
        return Task.FromResult(groupId.ToString().ToUpper());
    }

    protected override Expression<Func<Translation, bool>> GetGroupWordsFilter(char id)
    {
        return translation => translation.Meaning.Word.Text.StartsWith(id);
    }
}