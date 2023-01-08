using Laraue.Apps.LearnLanguage.DataAccess;
using Laraue.Apps.LearnLanguage.DataAccess.Enums;
using LinqToDB;
using MediatR;

namespace Laraue.Apps.LearnLanguage.Commands.Queries;

public class GetWordQuery : IRequest<WordData>
{
    public string UserId { get; init; }

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
        return _databaseContext.WordGroupWordTranslations
            .Where(x => x.SerialNumber == request.SerialNumber
                && x.WordGroup.UserId == request.UserId)
            .Select(x => new WordData(
                x.WordTranslation.Word.Name,
                x.WordTranslation.Translation,
                x.WordGroup.SerialNumber,
                x.LearnState,
                request.SerialNumber))
            .FirstAsync(cancellationToken);
    }
}