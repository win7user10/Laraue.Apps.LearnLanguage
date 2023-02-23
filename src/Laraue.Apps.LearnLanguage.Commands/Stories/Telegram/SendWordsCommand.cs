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

    public int? OpenedWordIndex { get; init; }

    public LearnState? LearnState { get; init; }

    public long[]? CurrentlyOpenedWords { get; init; }
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

        long? openedWordSerialNumber = request.CurrentlyOpenedWords is not null && request.OpenedWordIndex is not null
            ? request.CurrentlyOpenedWords[request.OpenedWordIndex.Value]
            : null;
        
        if (request.LearnState is not null && openedWordSerialNumber is not null)
        {
            // TODO - send id instead of serial number
            await _mediator.Send(
                new ChangeWordLearnStateCommand(
                    request.UserId,
                    openedWordSerialNumber.Value,
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
                UserId = request.UserId,
                Id = request.GroupId,
                ShowWordsMode = userSettings.ShowWordsMode
            },
            cancellationToken);

        var idsForStatUpdate = result.Data.Select(x => x.SerialNumber)
            .Except(request.CurrentlyOpenedWords ?? Enumerable.Empty<long>())
            .ToArray();
        
        // Update view stat for the words 
        if (idsForStatUpdate.Length > 0)
        {
            // TODO - send id instead of serial number
            await _mediator.Send(
                new UpdateWordsStatCommand(
                    idsForStatUpdate,
                    request.UserId),
                cancellationToken);

            result = result.MapTo(x => idsForStatUpdate.Contains(x.SerialNumber)
                ? x with
                {
                    ViewCount = x.ViewCount + 1
                }
                : x);
        }

        await _mediator.Send(new RenderWordsViewCommand(
            result,
            userSettings,
            request.GroupId,
            request.Data.Message.Chat.Id,
            request.Data.Message.MessageId,
            openedWordSerialNumber,
            request.Data.Id),
            cancellationToken);

        return null;
    }
}