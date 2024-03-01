
namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdPriceUpdatedEvent(Guid Id, decimal price, string currencyCode) : DomainEvent(Id)
{
    public decimal? Price { get; set; } = price;
    public string? CurrencyCode { get; set; } = currencyCode;
}
