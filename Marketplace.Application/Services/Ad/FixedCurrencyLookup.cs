using Marketplace.Domain.Contexts.Ad.DomainServices;
using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Application.Services.Ad;
public class FixedCurrencyLookup : ICurrencyLookup
{
    private static readonly IEnumerable<CurrencyDetails> _currencies =
        new[]
        {
                new CurrencyDetails("EUR",true,2),
                new CurrencyDetails("USD",true,2)
        };

    public CurrencyDetails FindCurrency(string currencyCode)
    {
        var currency = _currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
        return currency ?? CurrencyDetails.None;
    }
}
