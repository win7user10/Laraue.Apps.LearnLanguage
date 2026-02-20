namespace Laraue.Apps.LearnLanguage.AppServices.Services;

public interface IQuestionsOrderRandomizer
{
    IQueryable<NewQuestionDto> InRandomOrder(IQueryable<NewQuestionDto> queryable);
    IEnumerable<NewQuestionDto> InRandomOrder(IEnumerable<NewQuestionDto> enumerable);
}

public class QuestionsOrderRandomizer : IQuestionsOrderRandomizer
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
}