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
                WordId = x.Translation.WordId,
                PartOfSpeechId = x.Translation.Word.PartOfSpeechId,
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
                WordId = x.Translation.WordId,
                PartOfSpeechId = x.Translation.Word.PartOfSpeechId,
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
                WordId = x.translation.WordId,
                PartOfSpeechId = x.translation.Word.PartOfSpeechId,
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
        var optionsData = await context.Translations
            .Where(x => x.LanguageId == languageId)
            .Select(x => new { x.WordId, x.Word.PartOfSpeechId })
            .ToArrayAsyncEF(ct);

        var optionIdsByPartOfSpeechId = optionsData
            .GroupBy(x => x.PartOfSpeechId)
            .ToDictionary(
                x => x.Key,
                x => x
                    .Select(y => y.WordId)
                    .ToArray());
        
        var allOptionIds = optionsData
            .Select(x => x.WordId)
            .ToArray();
        
        foreach (var question in questions)
        {
            var generatedOptions = new HashSet<long>
            {
                question.WordId, // the first option is the correct value
            };
            
            // As default tries to generate options with the same part of speech
            var partOfSpeechId = question.PartOfSpeechId;
            var optionsLength = optionIdsByPartOfSpeechId[partOfSpeechId].Length;
            var availableOptionIds = enrichCount > optionsLength
                ? allOptionIds
                : optionIdsByPartOfSpeechId[partOfSpeechId];
            
            for (var i = 0; i < enrichCount - 1; i++)
            {
                while (true)
                {
                    var nextOptionIndex = Random.Shared.Next(0, availableOptionIds.Length);
                    var optionId = availableOptionIds[nextOptionIndex];
                    
                    if (generatedOptions.Add(optionId))
                    {
                        break;
                    }
                }
            }

            question.OptionIds = generatedOptions.ToArray();
        }
    }
}

public class NewQuestionDto
{
    public required long WordId { get; set; }
    public required long PartOfSpeechId { get; set; }
    public long[] OptionIds { get; set; } = [];
}