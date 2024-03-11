using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Domain.Contexts.Ad.DomainServices;
public interface ICurrencyLookup
{
    CurrencyDetails FindCurrency(string currencyCode);
}
