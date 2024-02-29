using Marketplace.Domain.Contexts.Ad.Exceptions;

namespace Marketplace.Domain;
public record Money
{
    public readonly decimal Amount;
    public readonly string Currency;
    #region FACTORIES
    public static Money FromDecimal(decimal amount, string currency) => new(amount, currency);
    public static Money FromString(string amount, string currency) => new(decimal.Parse(amount), currency);
    #endregion

    protected Money(decimal amount, string currencyCode, ICurrencyLookup currencyLookup)
    {

    }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public Money Add(Money moneyToAdd) 
        => Currency == moneyToAdd.Currency
            ? new(Amount + moneyToAdd.Amount, Currency)
            : throw new CurrencyMismatchException("Cannot add amounts from different currencies.");

    public Money Substract(Money moneyToSubstract) 
        => Currency == moneyToSubstract.Currency
            ? new(Amount - moneyToSubstract.Amount, Currency)
            : throw new CurrencyMismatchException("Cannot add amounts from different currencies.");

    public static Money operator +(Money a, Money b) => a.Add(b);
    public static Money operator -(Money a, Money b) => a.Substract(b);

    public override string ToString() => $"{Amount} {Currency}";
}
