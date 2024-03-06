
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdPriceUpdatedEvent(Guid Id, decimal price, string currencyCode, int decimalPlaces, bool inUse) : DomainEvent(Id)
{
    public decimal Price { get; set; } = price;
    public string CurrencyCode { get; set; } = currencyCode;
    public int DecimalPlaces { get; set; } = decimalPlaces;
    public bool InUse { get; set; } = inUse;
}
