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
                    translation.WordId == state.WordId
                    && translation.MeaningId == state.MeaningId
                    && translation.Id == state.TranslationId
                    && state.UserId == userId,
                (translation, state) => new LearningItem
                {
                    IsMarked = state.IsMarked,
                    TranslationId = ToIdentifier(translation),
                    Translation = translation.Text,
                    Transcription = translation.Transcription,
                    Difficulty = translation.Difficulty,
                    LearnedAt = state.LearnedAt,
                    RepeatedAt = state.RepeatedAt,
                    Word = translation.Meaning.Word.Text,
                    CefrLevel = translation.Meaning.CefrLevel!.Name,
                    Meaning = translation.Meaning.Text,
                    Topics = context.MeaningTopics
                        .Where(x =>
                            x.WordId == translation.WordId
                            && x.MeaningId == translation.MeaningId)
                        .Select(wmt => wmt.Topic.Name)
                        .ToList(),
                });

        if (filter.HasFlag(ShowWordsMode.Hard))
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            dbQuery = dbQuery.Where(x => x.IsMarked);
        }

        if (filter.HasFlag(ShowWordsMode.NotLearned))
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            dbQuery = dbQuery.Where(x => x.LearnedAt == null);
        }

        return dbQuery
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