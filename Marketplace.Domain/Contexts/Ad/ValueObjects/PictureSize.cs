﻿using Marketplace.Framework.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;

[ComplexType]
public record PictureSize(double Height, double Width)
{
    private readonly bool _isValid = new ValidatorBuilder()
        .For(Width).NotLessThan(0)
        .For(Height).NotLessThan(0)
        .IsValid();
}
