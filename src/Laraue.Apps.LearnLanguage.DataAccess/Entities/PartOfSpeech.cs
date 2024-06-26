﻿using System.ComponentModel.DataAnnotations;

namespace Laraue.Apps.LearnLanguage.DataAccess.Entities;

public class PartOfSpeech : BaseEntity, IDictionaryEntity
{
    [MaxLength(10)]
    public required string Name { get; init; }
}