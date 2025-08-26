using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public interface ISelectLanguageService
{
    Task ShowLanguageWindowOrHandleRequestAsync<TRequest>(
        TRequest request,
        string languageWindowTitle,
        string nextRoute,
        ReplyData replyData,
        Func<TRequest, ReplyData, SelectedTranslation, CancellationToken, Task> handleRequestAsync,
        CancellationToken ct = default)
        where TRequest : WithSelectedTranslationRequest;
}