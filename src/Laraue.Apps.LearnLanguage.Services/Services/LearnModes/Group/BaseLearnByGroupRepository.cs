using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes.Group;

public abstract class BaseLearnByGroupRepository<TId>(DatabaseContext context)
    : ILearnByGroupRepository<TId> where TId : struct
{
    public Task<IFullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        TId groupId,
        Guid userId,
        ShowWordsMode filter,
        PaginatedRequest request,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var dbQuery = context.Translations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId))
            .Where(GetGroupWordsFilter(groupId))
            .OrderBy(x => x.Meaning.Id)
            .LeftJoin(
                context.TranslationStates,
                (translation, state) => translation.Id == state.TranslationId && state.UserId == userId,
                (translation, state) => new { translation, state });

        if (filter.HasFlag(ShowWordsMode.Hard))
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            dbQuery = dbQuery.Where(x => x.state.IsMarked);
        }

        if (filter.HasFlag(ShowWordsMode.NotLearned))
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            dbQuery = dbQuery.Where(x => x.state == null || x.state.LearnedAt == null);
        }
        
        return dbQuery
            .Select((x, i) => new LearningItem(
                x.translation.Meaning.Word.Text,
                x.translation.Text,
                x.translation.Meaning.Text,
                request.Page * request.PerPage + i + 1,
                x.state.IsMarked,
                x.translation.Difficulty,
                new TranslationIdentifier
                {
                    MeaningId = x.translation.MeaningId,
                    TranslationId = x.translation.Id,
                    WordId = x.translation.Meaning.WordId
                },
                x.translation.Meaning.CefrLevel!.Name,
                x.translation.Meaning.Topics.Select(wmt => wmt.Topic.Name).ToArray(),
                x.state.LearnedAt,
                x.state.RepeatedAt
            ))
            .FullPaginateLinq2DbAsync(request, ct);;
    }

    public abstract Task<IList<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default);

    public abstract Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
    
    protected abstract Expression<Func<Translation, bool>> GetGroupWordsFilter(TId id);
}