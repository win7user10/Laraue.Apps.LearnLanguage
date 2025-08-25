using Laraue.Apps.LearnLanguage.DataAccess;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public interface IQuestionsGenerator
{
    Task<NewQuestionDto[]> GenerateQuestions(
        Guid userId,
        long languageId,
        int questionsCount,
        int optionsCount,
        CancellationToken ct);
}

public class QuestionsGenerator(DatabaseContext context) : IQuestionsGenerator
{
    public async Task<NewQuestionDto[]> GenerateQuestions(
        Guid userId,
        long languageId,
        int questionsCount,
        int optionsCount,
        CancellationToken ct)
    {
        const double rememberWordsRatio = 0.2;
        const double repeatWordsRatio = 0.6;

        var preferredRememberWordsCount = (int)(questionsCount * rememberWordsRatio);
        var preferredRepeatWordsCount = (int)(questionsCount * repeatWordsRatio);

        var oldQuestions = await context.LearnedTranslations
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt != null)
            .Where(x => x.Translation.LanguageId == languageId)
            .Select(x => new NewQuestionDto
            {
                WordId = x.Translation.WordId
            })
            .OrderBy(x => Guid.NewGuid())
            .Take(preferredRememberWordsCount)
            .ToListAsyncEF(ct);
        
        // If remember words are less than excepted, request more words to repeat
        var repeatWordsCount = preferredRepeatWordsCount + preferredRememberWordsCount - oldQuestions.Count;
        
        var repeatQuestions = await context.LearnedTranslations
            .Where(x => x.UserId == userId)
            .Where(x => x.LearnedAt == null)
            .Where(x => x.LanguageId == languageId)
            .Select(x => new NewQuestionDto
            {
                WordId = x.Translation.WordId
            })
            .OrderBy(x => Guid.NewGuid())
            .Take(repeatWordsCount)
            .ToListAsyncEF(ct);
        
        var newQuestionsCount = questionsCount - oldQuestions.Count - repeatQuestions.Count;
        var newQuestions = await context.Translations
            .LeftJoin(
                context.LearnedTranslations,
                (translation, learnedTranslation) => translation.LanguageId == learnedTranslation.LanguageId && translation.WordId == learnedTranslation.WordId,
                (translation, learnedTranslation) => new { translation, learnedTranslation })
            .Where(x => x.translation.LanguageId == languageId)
            .Where(x => x.learnedTranslation == null)
            .OrderBy(x => SqlFunctions.NewGuid())
            .Take(newQuestionsCount)
            .Select(x => new NewQuestionDto
            {
                WordId = x.translation.WordId
            })
            .ToListAsyncEF(ct);

        var allQuestions = oldQuestions
            .Union(repeatQuestions)
            .Union(newQuestions)
            .OrderBy(_ => Guid.NewGuid())
            .ToArray();
        
        await EnrichOptions(languageId, optionsCount, allQuestions, ct);
        
        return allQuestions;
    }

    private async Task EnrichOptions(long languageId, int enrichCount, NewQuestionDto[] questions, CancellationToken ct)
    {
        var allOptionIds = await context.Translations
            .Where(x => x.LanguageId == languageId)
            .Select(x => x.WordId)
            .ToArrayAsyncLinqToDB(ct);

        var optionsLength = allOptionIds.Length;
        
        foreach (var question in questions)
        {
            var generatedOptions = new HashSet<long>()
            {
                question.WordId, // first option is the correct value
            };
            
            for (var i = 0; i < enrichCount - 1; i++)
            {
                while (true)
                {
                    var nextOptionId = Random.Shared.Next(0, optionsLength);
                    if (generatedOptions.Add(nextOptionId))
                    {
                        break;
                    }
                }
            }

            question.OptionIds = generatedOptions.OrderBy(_ => Guid.NewGuid()).ToArray();
        }
    }
}

public class NewQuestionDto
{
    public required long WordId { get; set; }
    public long[] OptionIds { get; set; } = [];
}