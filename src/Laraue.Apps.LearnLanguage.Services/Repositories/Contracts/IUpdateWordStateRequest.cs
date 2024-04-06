namespace Laraue.Apps.LearnLanguage.Services.Repositories.Contracts;

public interface IUpdateWordStateRequest : IWithTranslationIdentifierRequest
{
    /// <summary>
    /// When passed, learn state of the opened translation will be changed to this value.
    /// </summary>
    public bool? IsLearned  { get; init; }
    
    /// <summary>
    /// When passed, mark state of the opened translation will be changed to this value.
    /// </summary>
    public bool? IsMarked  { get; init; }
}