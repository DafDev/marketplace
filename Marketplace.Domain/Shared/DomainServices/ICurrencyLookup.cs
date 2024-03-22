using Marketplace.Domain.Shared.ValueObjects;

namespace Marketplace.Domain.Shared.DomainServices;
public interface ICurrencyLookup
{
    CurrencyDetails FindCurrency(string currencyCode);
}
