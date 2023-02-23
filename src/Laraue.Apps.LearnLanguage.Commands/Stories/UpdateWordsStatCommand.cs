using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record UpdateWordsStatCommand(long[] WordTranslationIds, string UserId) : IRequest;

public class UpdateWordsStatCommandHandler : IRequestHandler<UpdateWordsStatCommand>
{
    private readonly DatabaseContext _context;

    public UpdateWordsStatCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateWordsStatCommand request, CancellationToken cancellationToken)
    {
        await _context.WordTranslationStates.Where(x => 
            request.WordTranslationIds.Contains(x.WordTranslationId)
                && request.UserId == x.UserId)
            .UpdateAsync(x => new WordTranslationState
            {
                ViewCount = x.ViewCount + 1
            }, cancellationToken);
        
        return Unit.Value;
    }
}