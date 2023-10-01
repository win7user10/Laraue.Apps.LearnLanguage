using Laraue.Apps.LearnLanguage.Commands.Queries;
using Laraue.Apps.LearnLanguage.Commands.Stories.Telegram.Views;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using Laraue.Core.DataAccess.Extensions;
using MediatR;
using Telegram.Bot.Types;

namespace Laraue.Apps.LearnLanguage.Commands.Stories.Telegram;

public record SendWordGroupWordsCommand : BaseCommand<CallbackQuery>
{
    public long GroupId { get; init; }

    public int Page { get; init; }

    public bool ToggleShowTranslations { get; init; }
    
    public bool ToggleRevertTranslations { get; init; }
    
    public ShowWordsMode? ShowMode { get; init; }

    public long? OpenedWordTranslationId { get; init; }

    public LearnState? LearnState { get; init; }
}

public class SendWordGroupWordsCommandHandler : IRequestHandler<SendWordGroupWordsCommand, object?>
{
    private readonly IMediator _mediator;

    public SendWordGroupWordsCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<object?> Handle(SendWordGroupWordsCommand request, CancellationToken cancellationToken)
    {
        if (request.ToggleShowTranslations)
        {
            await _mediator.Send(
                new ChangeWordsTemplateModeCommand(request.UserId, WordsTemplateMode.HideTranslations),
                cancellationToken);
        }
        
        if (request.ToggleRevertTranslations)
        {
            await _mediator.Send(
                new ChangeWordsTemplateModeCommand(request.UserId, WordsTemplateMode.RevertWordAndTranslation),
                cancellationToken);
        }

        if (request.ShowMode is not null)
        {
            await _mediator.Send(
                new ChangeShowWordsModeCommand(request.UserId, request.ShowMode.GetValueOrDefault()),
                cancellationToken);
        }
        
        if (request.LearnState is not null && request.OpenedWordTranslationId is not null)
        {
            await _mediator.Send(
                new ChangeWordLearnStateCommand(
                    request.UserId,
                    request.OpenedWordTranslationId.GetValueOrDefault(),
                    request.LearnState.GetValueOrDefault()),
                cancellationToken);
        }

        var userSettings = await _mediator.Send(
            new GetUserSettingsQuery(request.UserId),
            cancellationToken);
        
        var result = await _mediator.Send(
            new GetGroupWordsQuery
            {
                Page = request.Page,
                PerPage = Constants.PaginationCount,
                Id = request.GroupId,
                ShowWordsMode = userSettings.ShowWordsMode
            },
            cancellationToken);

        var closestGroups = await _mediator
            .Send(new GetClosestUnlearnedGroupsQuery(request.GroupId), cancellationToken);

        var idsForStatUpdate = result.Data.Select(x => x.TranslationId)
            .Except(userSettings.LastOpenedWordTranslationIds ?? Enumerable.Empty<long>())
            .ToArray();
        
        // Update view stat for the words 
        if (idsForStatUpdate.Length > 0)
        {
            await _mediator.Send(
                new UpdateWordsStatCommand(
                    idsForStatUpdate,
                    request.UserId),
                cancellationToken);

            result = result.MapTo(x => idsForStatUpdate.Contains(x.TranslationId)
                ? x with { ViewCount = x.ViewCount + 1 }
                : x);
        }

        var groupSerialNumber = await _mediator.Send(
            new GetGroupSerialNumberQuery
            {
                Id = request.GroupId,
            },
            cancellationToken);
        
        await _mediator.Send(new RenderWordsViewCommand(
            result,
            userSettings,
            closestGroups,
            request.GroupId,
            groupSerialNumber,
            request.Data.Message!.Chat.Id,
            request.Data.Message.MessageId,
            request.OpenedWordTranslationId,
            request.Data.Id),
            cancellationToken);

        await _mediator.Send(
            new UpdateLastViewedTranslationsCommand(
                result.Data.Select(x => x.TranslationId).ToArray(), 
                request.UserId),
            cancellationToken);

        return null;
    }
}