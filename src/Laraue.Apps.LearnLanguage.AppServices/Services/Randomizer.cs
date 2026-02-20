namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public interface IRandomizer
{
    IQueryable<NewQuestionDto> InRandomOrder(IQueryable<NewQuestionDto> queryable);
    IEnumerable<NewQuestionDto> InRandomOrder(IEnumerable<NewQuestionDto> enumerable);
    int NextRandomValue(int minValue, int maxValue);
}

public class Randomizer : IRandomizer
{
    public IQueryable<NewQuestionDto> InRandomOrder(IQueryable<NewQuestionDto> queryable)
    {
        return queryable
            .OrderBy(x => Guid.NewGuid());
    }

    public IEnumerable<NewQuestionDto> InRandomOrder(IEnumerable<NewQuestionDto> enumerable)
    {
        return enumerable
            .OrderBy(x => Guid.NewGuid());
    }

    public int NextRandomValue(int minValue, int maxValue)
    {
        return Random.Shared.Next(minValue, maxValue);
    }
}