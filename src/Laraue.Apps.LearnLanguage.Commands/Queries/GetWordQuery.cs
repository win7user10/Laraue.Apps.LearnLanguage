using Laraue.Apps.LearnLanguage.Commands.Extensions;
using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetWordQuery : IRequest<WordData>
{
    public Guid UserId { get; init; }

    public long SerialNumber { get; init; }
}

public record WordData(
    string Word,
    string Translation,
    long GroupSerialNumber,
    LearnState LearnState,
    long SerialNumber);

public class GetWordQueryHandler : IRequestHandler<GetWordQuery, WordData>
{
    private readonly DatabaseContext _databaseContext;

    public GetWordQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<WordData> Handle(GetWordQuery request, CancellationToken cancellationToken)
    {
        return _databaseContext.WordGroupWords
            .Where(x => x.SerialNumber == request.SerialNumber
                && x.WordGroup.UserId == request.UserId)
            .QueryGroupWordsWithStates(_databaseContext, (word, state) => new WordData(
                word.WordTranslation.Word.Name,
                word.WordTranslation.Translation,
                word.SerialNumber,
                state.LearnState,
                request.SerialNumber))
            .FirstAsync(cancellationToken);
    }
}