using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.UserProfile.ValueObjects;

[ComplexType]
public record FullName(string Value)
{
    public static FullName FromString(string value) 
        => string.IsNullOrWhiteSpace(value) 
        ? throw new ArgumentNullException(nameof(value))
        : new(value);

    public static implicit operator string(FullName self) => self.Value;
}
