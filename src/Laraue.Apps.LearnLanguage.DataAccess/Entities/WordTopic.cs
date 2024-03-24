﻿using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public sealed class WordTopic : BaseEntity, IDictionaryEntity
{
    [MaxLength(100)]
    public required string Name { get; init; }
}