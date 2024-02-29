using Marketplace.Domain.Contexts.Ad.DomainService;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record Price : Money
{
    public Price(decimal Amount, string currencyCode, ICurrencyLookup currencyLookup) 
        : base (Amount, currencyCode, currencyLookup)
    {
        if (Amount < 0)
            throw new ArgumentException("The price cannot be negative", nameof(Amount));
    }

}
