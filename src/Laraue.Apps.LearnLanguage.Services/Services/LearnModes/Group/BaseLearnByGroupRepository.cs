﻿using System.Linq.Expressions;
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
        var dbQuery = context.WordTranslations
            .Where(t => t.HasLanguage(
                selectedTranslation.LanguageToLearnId,
                selectedTranslation.LanguageToLearnFromId))
            .Where(GetGroupWordsFilter(groupId))
            .OrderBy(x => x.WordMeaning.Id)
            .LeftJoin(
                context.WordTranslationStates,
                (translation, state) => translation.Id == state.WordTranslationId && state.UserId == userId,
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
                x.translation.WordMeaning.Word.Name,
                x.translation.Translation,
                x.translation.WordMeaning.Meaning,
                request.Page * request.PerPage + i + 1,
                x.state.IsMarked,
                x.translation.Difficulty,
                x.translation.Id,
                x.translation.WordMeaning.WordCefrLevel!.Name,
                x.translation.WordMeaning.Topics.Select(wmt => wmt.WordTopic.Name).ToArray(),
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
    
    protected abstract Expression<Func<WordTranslation, bool>> GetGroupWordsFilter(TId id);
}