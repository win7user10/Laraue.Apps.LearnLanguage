namespace Laraue.Apps.LearnLanguage.AppServices.Options;

public class UtmLabelOption
{
    public required string Name { get; set; }
    public required string Value { get; set; }
    public required UtmLabelSettings Settings { get; set; }
}

public class UtmLabelSettings
{
    public int? LanguageToLearn { get; set; }
}