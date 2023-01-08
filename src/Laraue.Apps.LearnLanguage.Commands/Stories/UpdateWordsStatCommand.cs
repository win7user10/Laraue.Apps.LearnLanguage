using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record UpdateWordsStatCommand(long[] SerialNumbers, string UserId) : IRequest;

public class UpdateWordsStatCommandHandler : IRequestHandler<UpdateWordsStatCommand>
{
    private readonly DatabaseContext _context;

    public UpdateWordsStatCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWordsStatCommand request, CancellationToken cancellationToken)
    {
        await _context.WordGroupWordTranslations.Where(x => 
                request.SerialNumbers.Contains(x.SerialNumber)
                && request.UserId == x.WordGroup.UserId)
            .UpdateAsync(x => new WordGroupWords
            {
                ViewCount = x.ViewCount + 1
            }, cancellationToken);
        
        return Unit.Value;
    }
}