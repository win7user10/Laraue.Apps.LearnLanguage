using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group.FirstLetter;

public class LearnByFirstLetterRepository(DatabaseContext context)
    : BaseLearnByGroupRepository<char>(context), ILearnByFirstLetterRepository
{
    private readonly DatabaseContext _context = context;

    public override async Task<IList<LearningItemGroup<char>>> GetGroupsAsync(Guid userId, CancellationToken ct = default)
    {
        return await _context.WordTranslations
            .GroupBy(x => x.WordMeaning.Word.Name.Substring(0, 1))
            .OrderBy(x => x.Key)
            .Select((x, i) => new LearningItemGroup<char>(
                x.Key[0],
                _context.WordTranslationStates
                    .Count(y => y.UserId == userId
                                && y.WordTranslation.WordMeaning.Word.Name.StartsWith(x.Key)),
                x.Count(),
                x.Key.ToUpper()))
            .ToListAsyncLinqToDB(ct);
    }

    public override Task<string> GetGroupNameAsync(char groupId, CancellationToken ct = default)
    {
        return Task.FromResult(groupId.ToString().ToUpper());
    }

    protected override Expression<Func<WordTranslation, bool>> GetGroupWordsFilter(char id)
    {
        return translation => translation.WordMeaning.Word.Name.StartsWith(id);
    }
}