namespace Laraue.Apps.LearnLanguage.Common;

public class InterfaceLanguage
{
    public string Code { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;

    public static InterfaceLanguage[] Available { get; } =
    [
        new InterfaceLanguage { Code = "en", Title = "English" },
        new InterfaceLanguage { Code = "ru", Title = "Русский" },
    ];

    public static InterfaceLanguage Default => Available[0];

    public static InterfaceLanguage ForCode(string? code)
    {
        return Available.FirstOrDefault(x => x.Code == code) ?? Default;
    }
}