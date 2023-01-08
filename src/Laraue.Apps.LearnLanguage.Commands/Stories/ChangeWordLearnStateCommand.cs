using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Entities;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Stories;

public record ChangeWordLearnStateCommand(
    string UserId,
    long SerialNumber,
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
        return _context.WordGroupWordTranslations.Where(x => x.WordGroup.UserId == request.UserId
            && x.SerialNumber == request.SerialNumber)
            .UpdateAsync(x => new WordGroupWords
            {
                LearnState = x.LearnState ^ request.FlagToChange,
                LearnedAt = request.FlagToChange == LearnState.Learned
                    ? (x.LearnState & LearnState.Learned) == 0
                        ? DateTimeOffset.UtcNow
                        : null
                    : x.LearnedAt
            }, cancellationToken);
    }
}