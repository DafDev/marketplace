using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.ValueObjects;

namespace Marketplace.Application.Shared.Services;
public class FixedCurrencyLookup : ICurrencyLookup
{
    private static readonly IEnumerable<CurrencyDetails> _currencies =
        new[]
        {
                new CurrencyDetails("EUR",true,2),
                new CurrencyDetails("USD",true,2),
                new CurrencyDetails("JPY",true,0),
        };

    public CurrencyDetails FindCurrency(string currencyCode)
    {
        var currency = _currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
        return currency ?? CurrencyDetails.None;
    }
}