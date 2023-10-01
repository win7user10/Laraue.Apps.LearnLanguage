using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record UpdateWordsStatCommand(long[] WordTranslationIds, Guid UserId) : IRequest;

public class UpdateWordsStatCommandHandler : IRequestHandler<UpdateWordsStatCommand>
{
    private readonly DatabaseContext _context;

    public UpdateWordsStatCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateWordsStatCommand request, CancellationToken cancellationToken)
    {
        var updatedCount = await _context.WordTranslationStates
            .Where(x => 
                request.WordTranslationIds.Contains(x.WordTranslationId)
                    && request.UserId == x.UserId)
            .UpdateAsync(x => new WordTranslationState
            {
                ViewCount = x.ViewCount + 1
            }, cancellationToken);

        if (updatedCount == request.WordTranslationIds.Length)
        {
            return;
        }
        
        var existsStates = await _context.WordTranslationStates
            .Where(x =>
                request.WordTranslationIds.Contains(x.WordTranslationId)
                && request.UserId == x.UserId)
            .Select(x => x.WordTranslationId)
            .ToListAsync(cancellationToken);

        foreach (var wordTranslationId in request.WordTranslationIds.Except(existsStates))
        {
            _context.WordTranslationStates.Add(new WordTranslationState
            {
                ViewCount = 1,
                WordTranslationId = wordTranslationId,
                UserId = request.UserId,
            });
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}