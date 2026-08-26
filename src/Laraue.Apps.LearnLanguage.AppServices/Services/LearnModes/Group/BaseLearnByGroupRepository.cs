using System.Linq.Expressions;
using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Apps.LearnLanguage.Contracts;
using Laraue.Apps.LearnLanguage.Contracts.Enums;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Core.DataAccess.Contracts;
using Laraue.Core.DataAccess.Linq2DB.Extensions;
using LinqToDB;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes.Group;

public abstract class BaseLearnByGroupRepository<TId>(DatabaseContext context)
    : ILearnByGroupRepository<TId> where TId : struct
{
    public Task<FullPaginatedResult<LearningItem>> GetGroupWordsAsync(
        TId groupId,
        Guid userId,
        ShowWordsMode filter,
        IPaginationData request,
        SelectedTranslation selectedTranslation,
        CancellationToken ct = default)
    {
        var dbQuery = context.Translations
            .Where(t => t.HasLanguage(selectedTranslation.LanguageToLearnId))
            .Where(GetGroupWordsFilter(groupId))
            .LeftJoin(
                context.LearnedTranslations,
                (translation, state) => 
                    translation.WordId == state.WordId
                    && translation.LanguageId == state.LanguageId
                    && state.UserId == userId,
                (translation, state) => new LearningItem
                {
                    TranslationId = ToIdentifier(translation),
                    Translation = translation.Text,
                    Transcription = translation.Transcription,
                    Difficulty = translation.Difficulty,
                    LearnedAt = state.LearnedAt,
                    Word = translation.Word.Text,
                    CefrLevel = translation.Word.CefrLevel!.Name,
                    Meaning = translation.Word.Meaning,
                    PartOfSpeech = translation.Word.PartOfSpeech!.Name,
                    Topics = context.WordTopics
                        .Where(x => x.WordId == translation.WordId)
                        .Select(wmt => wmt.Topic.Name)
                        .ToList(),
                });

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
            LanguageId = x.LanguageId,
            WordId = x.WordId
        };
    }

    public abstract Task<FullPaginatedResult<LearningItemGroup<TId>>> GetGroupsAsync(
        Guid userId,
        SelectedTranslation selectedTranslation,
        IPaginationData request,
        CancellationToken ct = default);

    public abstract Task<string> GetGroupNameAsync(TId groupId, CancellationToken ct = default);
    
    protected abstract Expression<Func<Translation, bool>> GetGroupWordsFilter(TId id);
}