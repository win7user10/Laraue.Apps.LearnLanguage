using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using MediatR;
using User = Laraue.Apps.LearnLanguage.DataAccess.Entities.User;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record ChangeShowWordsModeCommand(string UserId, ShowWordsMode NewMode) : IRequest<int>;

public class ChangeShowWordsModeCommandHandler : IRequestHandler<ChangeShowWordsModeCommand, int>
{
    private readonly DatabaseContext _context;

    public ChangeShowWordsModeCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public Task<int> Handle(ChangeShowWordsModeCommand request, CancellationToken cancellationToken)
    {
        return _context.Users
            .ToLinqToDBTable()
            .Where(x => x.Id == request.UserId)
            .UpdateAsync(
                x => new User { ShowWordsMode = request.NewMode },
                cancellationToken);
    }
}