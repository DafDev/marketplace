using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.ValueObjects;

namespace Marketplace.Tests.Contexts.Ad.DomainServices;
internal class FakeCurrencyLookup : ICurrencyLookup
{
    private readonly IEnumerable<CurrencyDetails> _currencyDetails =
        [
            new("EUR", true, 2),
            new("USD", true, 2),
            new("JPY", true, 0),
            new("DEM", false, 0),
        ];

    public CurrencyDetails FindCurrency(string currencyCode) => _currencyDetails
            .FirstOrDefault(currencyDetails => currencyDetails.CurrencyCode.Equals(currencyCode, StringComparison.InvariantCultureIgnoreCase))
            ?? CurrencyDetails.None;
}
