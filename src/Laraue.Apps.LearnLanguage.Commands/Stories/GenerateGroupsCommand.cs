using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record GenerateGroupsCommand(string UserId, bool ShuffleWords) : IRequest;

public class FormNewLearningBatchCommandHandler : IRequestHandler<GenerateGroupsCommand>
{
    private readonly DatabaseContext _context;

    public FormNewLearningBatchCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(GenerateGroupsCommand request, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        var idsToInsert = await _context.WordTranslations
            .Select(x => x.WordId)
            .ToArrayAsync(cancellationToken);
        
        if (request.ShuffleWords)
        {
            idsToInsert = idsToInsert.OrderBy(_ => Guid.NewGuid()).ToArray();
        }

        var wordGroups = idsToInsert.Chunk(Constants.WordGroupSize)
            .Select((group, wi) => new WordGroup
            {
                UserId = request.UserId,
                WordGroupWords = group
                    .Select((x, ti) => new WordGroupWord
                    {
                        WordTranslationId = x,
                        SerialNumber = wi * Constants.WordGroupSize + ti + 1,
                    })
                    .ToList(),
                SerialNumber = wi + 1
            });
        
        _context.WordGroups.AddRange(wordGroups);

        await _context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        
        return Unit.Value;
    }
}