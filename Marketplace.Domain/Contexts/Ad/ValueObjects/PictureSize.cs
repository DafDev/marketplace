using Marketplace.Framework;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record PictureSize(double Height, double Width)
{
    private readonly bool _isValid = new ValidatorBuilder()
        .For(Width).LessThan(0)
        .For(Height).LessThan(0)
        .IsValid();
}
