namespace Marketplace.Domain;
public record Price : Money
{
    public Price(decimal Amount) : base (Amount)
    {
        if (Amount < 0)
            throw new ArgumentException("The price cannot be negative", nameof(Amount));
    }

}
