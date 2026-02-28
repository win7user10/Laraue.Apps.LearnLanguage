using Laraue.Apps.LearnLanguage.AppServices.Repositories.Contracts;
using Laraue.Telegram.NET.Core.Routing;
using Laraue.Telegram.NET.Core.Utils;

namespace Laraue.Apps.LearnLanguage.AppServices.Services.LearnModes;

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

    Task AppendLanguagePairButtonsAsync(
        TelegramMessageBuilder messageBuilder,
        CallbackRoutePath nextRoute,
        CancellationToken ct);
}