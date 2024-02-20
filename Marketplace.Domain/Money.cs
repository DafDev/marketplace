namespace Marketplace.Domain;
public record Money(decimal Amount)
{
    public Money Add(Money moneyToAdd) => new(Amount + moneyToAdd.Amount);
    public Money Substract(Money moneyToSubstract) => new(Amount - moneyToSubstract.Amount);
    public static Money operator +(Money a, Money b) => a.Add(b);
    public static Money operator -(Money a, Money b) => a.Substract(b);
}
