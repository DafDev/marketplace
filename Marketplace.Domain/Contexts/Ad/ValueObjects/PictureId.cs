namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record PictureId(Guid Value)
{
    public static implicit operator Guid(PictureId self) => self.Value;
}
