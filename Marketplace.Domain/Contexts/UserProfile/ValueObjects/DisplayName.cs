﻿using Marketplace.Domain.Shared.DomainServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.UserProfile.ValueObjects;
[ComplexType]
public record DisplayName(string Value)
{
    public static DisplayName FromString(string value, CheckTextForProfanity hasProfanity)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));
       
        if (hasProfanity(value))
            throw new ProfanityFoundException(value);
        
        return  new(value);
    }

    public static implicit operator string(DisplayName self) => self.Value;
}
