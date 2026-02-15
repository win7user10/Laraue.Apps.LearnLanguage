namespace Laraue.Apps.LearnLanguage.AppServices.Services.Quiz;

public interface IQuizService
{
    Task OpenQuizWindowAsync(
        ReplyData replyData,
        QuizRequest request,
        CancellationToken ct = default);

    Task OpenSelectTopicWindowAsync(
        ReplyData replyData,
        SelectTopicRequest request,
        CancellationToken ct = default);

    Task ChangeTopicAsync(
        ReplyData replyData,
        ChangeTopicRequest request,
        CancellationToken ct = default);
    
    Task OpenSelectCefrLevelWindowAsync(
        ReplyData replyData,
        SelectCefrLevelRequest request,
        CancellationToken ct = default);

    Task ChangeCefrLevelAsync(
        ReplyData replyData,
        ChangeCefrLevelRequest request,
        CancellationToken ct = default);

    Task StartNewQuizAsync(
        ReplyData replyData,
        StartQuizRequest startQuizRequest,
        CancellationToken ct = default);

    Task SelectQuizAnswerAsync(
        ReplyData replyData,
        SelectQuizAnswerRequest request,
        CancellationToken ct = default);

    Task FinishQuizAsync(
        ReplyData replyData,
        CancellationToken ct = default);
}