using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Shared.ValueObjects;

[ComplexType]
public record UserId(Guid Value)
{
    public static implicit operator Guid(UserId self) => self.Value;
}
