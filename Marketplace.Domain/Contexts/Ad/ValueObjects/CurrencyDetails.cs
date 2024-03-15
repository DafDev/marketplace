using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;

[ComplexType]
public record CurrencyDetails(string CurrencyCode, bool InUse, int DecimalPlaces)
{
    public static CurrencyDetails None => new(string.Empty, false, default);
}
