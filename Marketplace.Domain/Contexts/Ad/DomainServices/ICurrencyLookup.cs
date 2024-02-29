using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Domain.Contexts.Ad.DomainService;
public interface ICurrencyLookup
{
    CurrencyDetails FindCurrency(string currencyCode);
}
