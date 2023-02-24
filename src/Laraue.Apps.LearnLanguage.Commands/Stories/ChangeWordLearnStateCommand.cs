using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record ChangeWordLearnStateCommand(
    string UserId,
    long WordTranslationId,
    LearnState FlagToChange)
    : IRequest<int>;

public class ChangeWordIsLearningStateCommandHandler : IRequestHandler<ChangeWordLearnStateCommand, int>
{
    private readonly DatabaseContext _context;

    public ChangeWordIsLearningStateCommandHandler(DatabaseContext context)
    {
        _context = context;
    }

    public Task<int> Handle(ChangeWordLearnStateCommand request, CancellationToken cancellationToken)
    {
        return _context.WordTranslationStates
            .ToLinqToDBTable()
            .InsertOrUpdateAsync(
                () => new WordTranslationState
                {
                    WordTranslationId = request.WordTranslationId,
                    UserId = request.UserId,
                    LearnState = LearnState.None ^ request.FlagToChange,
                    LearnedAt = request.FlagToChange == LearnState.Learned
                        ? DateTimeOffset.UtcNow
                        : null,
                    ViewCount = 1,
                }, x => new WordTranslationState
                {
                    LearnState = x.LearnState ^ request.FlagToChange,
                    LearnedAt = request.FlagToChange == LearnState.Learned
                        ? (x.LearnState & LearnState.Learned) == 0
                            ? DateTimeOffset.UtcNow
                            : null
                        : x.LearnedAt
                },
                () => new WordTranslationState
                {
                    UserId = request.UserId,
                    WordTranslationId = request.WordTranslationId,
                },
                cancellationToken);
    }
}