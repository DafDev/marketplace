using Marketplace.Domain.Contexts.Ad.DomainServices;
using Marketplace.Domain.Contexts.Ad.Exceptions;

namespace Marketplace.Domain.Contexts.Ad.ValueObjects;
public record class Money
{
    public decimal Amount { get; init; }
    public CurrencyDetails Currency { get; init; }

    #region FACTORIES
    public static Money FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) => new(amount, currency, currencyLookup);
    public static Money FromString(string amount, string currency, ICurrencyLookup currencyLookup) => new(decimal.Parse(amount), currency, currencyLookup);
    #endregion

    #region CONSTRUCTORS
    protected Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            throw new ArgumentNullException(nameof(currencyCode), "Currency must be specified");

        if (amount < 0)
            throw new ArgumentException("The price cannot be negative", nameof(amount));

        CurrencyDetails currencyDetails = currencyLookup.FindCurrency(currencyCode);

        if (!currencyDetails.InUse)
            throw new CurrencyNotInUseException($"Currency {currencyCode} is not valid");

        if (decimal.Round(amount, currencyDetails.DecimalPlaces) != amount)
            throw new TooManyDecimalsException($"Currency {currencyDetails.CurrencyCode} cannot have more than {currencyDetails.DecimalPlaces} decimals.");

        Amount = amount;
        Currency = currencyDetails;
    }

    internal Money(decimal amount, string currencyCode, bool inUse, int decimalPlaces)
    {
        Amount = amount;
        Currency = new(currencyCode, inUse, decimalPlaces);
    }

    private Money(decimal amount, CurrencyDetails currency)
    {
        Amount = amount;
        Currency = currency;
    }
    #endregion

    #region ADD/SUBSTRACT
    public Money Add(Money moneyToAdd)
    => Currency == moneyToAdd.Currency
        ? new(Amount + moneyToAdd.Amount, Currency)
        : throw new CurrencyMismatchException("Cannot add amounts from different currencies.");

    public Money Substract(Money moneyToSubstract)
        => Currency == moneyToSubstract.Currency
            ? new(Amount - moneyToSubstract.Amount, Currency)
            : throw new CurrencyMismatchException("Cannot substract amounts from different currencies.");

    public static Money operator +(Money a, Money b) => a.Add(b);
    public static Money operator -(Money a, Money b) => a.Substract(b); 
    #endregion

    public override string ToString() => $"{Currency.CurrencyCode} {Amount}";
}
