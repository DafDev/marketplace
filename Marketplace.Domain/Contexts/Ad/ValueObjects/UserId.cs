namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record UserId(Guid Value)
{
    public static implicit operator Guid(UserId self) => self.Value;
}
