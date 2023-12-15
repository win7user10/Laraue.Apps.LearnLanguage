using Laraue.Apps.LearnLanguage.DataAccess.Enums;

namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public record Word(
    string Text,
    string Translation,
    long GroupSerialNumber,
    LearnState LearnState,
    long SerialNumber);