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
            .Where(t => t.HasLanguage(selectedTranslation.LanguageToLearnId, selectedTranslation.LanguageToLearnFromId))
            .Where(GetGroupWordsFilter(groupId))
            .OrderBy(x => x.Meaning.Id)
            .LeftJoin(
                context.TranslationStates,
                (translation, state) => 
                    translation.Id == state.TranslationId
                    && translation.MeaningId == state.MeaningId
                    && translation.WordId == state.WordId
                    && state.UserId == userId,
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
            .Select(x => new LearningItem
            {
                Word = x.translation.Meaning.Word.Text,
                Translation = x.translation.Text,
                Meaning = x.translation.Meaning.Text,
                IsMarked = x.state.IsMarked,
                Difficulty = x.translation.Difficulty,
                LearnedAt = x.state.LearnedAt,
                RepeatedAt = x.state.RepeatedAt,
                TranslationId = ToIdentifier(x.translation),
                CefrLevel = x.translation.Meaning.CefrLevel!.Name,
                Topics = x.translation.Meaning.Topics.Select(wmt => wmt.Topic.Name).ToList(),
            })
            .FullPaginateLinq2DbAsync(request, ct);;
    }
    
    [ExpressionMethod(nameof(ToIdentifier))]
    public static TranslationIdentifier ToIdentifier(
        Translation translation)
    {
        throw new InvalidOperationException();
    }
    
    public static Expression<Func<Translation, TranslationIdentifier>> ToIdentifier()
    {
        return x => new TranslationIdentifier
        {
            MeaningId = x.MeaningId,
            TranslationId = x.Id,
            WordId = x.Meaning.WordId
        };
    }

    public abstract Task<IList<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default);

    public abstract Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
    
    protected abstract Expression<Func<Translation, bool>> GetGroupWordsFilter(TId id);
}