﻿namespace Laraue.Apps.LearnLanguage.EditorHost.Services;

public interface IAutoTranslator
{
    Task<TranslationResult> TranslateAsync(TranslationData translationData);
}

public record TranslationData
{
    public required string Word { get; set; }
    public required string FromLanguage { get; set; }
    public required string[] ToLanguages { get; set; }
}

public record TranslationResult
{
    public required Dictionary<string, TranslationResultItem> Items { get; set; }
}

public record TranslationResultItem
{
    public required string? Translation { get; set; }
}