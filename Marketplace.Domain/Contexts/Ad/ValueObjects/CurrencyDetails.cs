namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record CurrencyDetails(string CurrencyCode, bool InUse, int DecimalPlaces)
{
    public static CurrencyDetails None => new(string.Empty, false, default);
}
