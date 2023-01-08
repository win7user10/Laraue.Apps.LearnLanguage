using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using MediatR;
using User = Laraue.Apps.LearnLanguage.DataAccess.Entities.User;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record ChangeWordsTemplateModeCommand(string UserId, WordsTemplateMode FlagToChange) : IRequest<WordsTemplateMode>;

public class ChangeWordsTemplateModeCommandHandler : IRequestHandler<ChangeWordsTemplateModeCommand, WordsTemplateMode>
{
    private readonly DatabaseContext _context;

    public ChangeWordsTemplateModeCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<WordsTemplateMode> Handle(ChangeWordsTemplateModeCommand request, CancellationToken cancellationToken)
    {
        var result = await _context.Users
            .ToLinqToDBTable()
            .Where(x => x.Id == request.UserId)
            .UpdateWithOutputAsync(
                x => new User { WordsTemplateMode = x.WordsTemplateMode ^ request.FlagToChange },
                (oldUser, newUser) => newUser.WordsTemplateMode,
                cancellationToken);

        return result.FirstOrDefault();
    }
}