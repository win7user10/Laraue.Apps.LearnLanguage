namespace Laraue.Apps.LearnLanguage.AppServices;

public class InterfaceLanguage
{
    public string Code { get; init; } = string.Empty;

    public string Title { get; init; } = string.Empty;

    public static InterfaceLanguage[] Available { get; } =
    [
        new() { Code = "en", Title = "English" },
        new() { Code = "ru", Title = "Russian" },
    ];

    public static InterfaceLanguage Default => Available[0];

    public static InterfaceLanguage ForCode(string? code)
    {
        return Available.FirstOrDefault(x => x.Code == code) ?? Default;
    }
}