using System.Globalization;
using Laraue.Apps.LearnLanguage.Common;
using Laraue.Apps.LearnLanguage.Services.Repositories;
using Laraue.Telegram.NET.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Laraue.Apps.LearnLanguage.Services.Services;

public class LocalizationProvider : BaseCultureInfoProvider
{
    private readonly RequestContext _context;
    private readonly IUserRepository _userRepository;

    public LocalizationProvider(
        RequestContext context,
        IOptions<TelegramRequestLocalizationOptions> options,
        ILogger<BaseCultureInfoProvider> logger,
        IUserRepository userRepository)
        : base(context, options, logger)
    {
        _context = context;
        _userRepository = userRepository;
    }

    protected override async Task<TelegramProviderCultureResult> DetermineProviderCultureResultAsync(
        CultureInfo userInterfaceCulture,
        CancellationToken cancellationToken = default)
    {
        // TODO - make optimization to decrease requests count
        var settings = await _userRepository
            .GetSettingsAsync(_context.UserId, cancellationToken);

        var language = InterfaceLanguage.ForCode(settings.LanguageCode);

        return new TelegramProviderCultureResult(
            new CultureInfo(language.Code),
            new CultureInfo(language.Code));
    }
}