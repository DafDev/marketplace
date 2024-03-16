using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects; 
[ComplexType]
public record ClassifiedAdId(Guid Value)
{
    public static implicit operator Guid(ClassifiedAdId self) => self.Value;
}
