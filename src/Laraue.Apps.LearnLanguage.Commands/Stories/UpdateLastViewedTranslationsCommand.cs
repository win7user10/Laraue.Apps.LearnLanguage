using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record UpdateLastViewedTranslationsCommand(long[] WordTranslationIds, Guid UserId) : IRequest;

public class UpdateLastViewedTranslationsCommandHandler : IRequestHandler<UpdateLastViewedTranslationsCommand>
{
    private readonly DatabaseContext _context;

    public UpdateLastViewedTranslationsCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateLastViewedTranslationsCommand request, CancellationToken cancellationToken)
    {
        await _context.Users.Where(x => x.Id == request.UserId)
            .UpdateAsync(x => new User
            {
                LastOpenedTranslationIds = request.WordTranslationIds
            }, cancellationToken);
    }
}