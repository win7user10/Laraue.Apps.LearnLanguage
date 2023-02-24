using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public record GetUserSettingsQuery(string UserId) : IRequest<UserSettings>;

public record UserSettings(
    WordsTemplateMode WordsTemplateMode,
    ShowWordsMode ShowWordsMode,
    long[]? LastOpenedWordTranslationIds);

public class GetUserSettingsQueryHandler : IRequestHandler<GetUserSettingsQuery, UserSettings>
{
    private readonly DatabaseContext _context;

    public GetUserSettingsQueryHandler(DatabaseContext context)
    {
        _context = context;
    }

    public Task<UserSettings> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
    {
        return _context.Users
            .Where(x => x.Id == request.UserId)
            .Select(x => new UserSettings(x.WordsTemplateMode, x.ShowWordsMode, x.LastOpenedTranslationIds))
            .FirstAsyncLinqToDB(cancellationToken);
    }
}