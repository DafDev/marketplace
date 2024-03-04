namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record ClassifiedAdId(Guid Value)
{
    public static implicit operator Guid(ClassifiedAdId self) => self.Value;
}
