using Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

namespace Laraue.Apps.LearnLanguage.Services.Services.LearnModes;

public interface ISelectLanguageService
{
    Task ShowLanguageWindowOrHandleRequestAsync(
        WithSelectedTranslationRequest request,
        string languageWindowTitle,
        string nextRoute,
        ReplyData replyData,
        Func<ReplyData, SelectedTranslation, CancellationToken, Task> handleRequestAsync,
        CancellationToken ct = default);
}