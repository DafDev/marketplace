using Marketplace.Domain.Contexts.Ad.DomainService;
using Marketplace.Domain.Contexts.Ad.Exceptions;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Tests.Contexts.Ad.DomainServices;

namespace Marketplace.Tests.Contexts.Ad.ValueObjects;
public class MoneyTests
{
    private readonly ICurrencyLookup _currencyLookup = new FakeCurrencyLookup();

    [Fact]
    public void GivenMoneyObjectsWithSameAmountShouldBeEqual()
    {
        //Given
        Money firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money secondAmount = Money.FromDecimal(5, "EUR", _currencyLookup);

        //Should
        firstAmount.Should().Be(secondAmount);
    }

    [Fact]
    public void GivenMoneyObjectsWithSameAmountFromStringAndDecimalShouldBeEqual()
    {
        //Given
        Money firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money secondAmount = Money.FromString("5,00", "EUR", _currencyLookup);
        //Should
        firstAmount.Should().Be(secondAmount);
    }

    [Fact]
    public void GivenMoneyObjectsWithDifferentAmountsTotalShouldBeEqualToSum()
    {
        //Given
        Money firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money secondAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money totalBanknote = Money.FromDecimal(10, "EUR", _currencyLookup);
        //Should
        totalBanknote.Should().Be(secondAmount + firstAmount);
    }

    [Fact]
    public void GivenMoneyObjectsWithDifferentAmountsTotalShouldBeEqualToDifference()
    {
        //Given
        Money firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money secondAmount = Money.FromDecimal(15, "EUR", _currencyLookup);
        Money totalBanknote = Money.FromDecimal(10, "EUR", _currencyLookup);
        //Should
        totalBanknote.Should().Be(secondAmount - firstAmount);
    }

    [Fact]
    public void GivenMoneyWithDifferentCurrencieWhenAddingShouldThrow()
    {
        //Given
        Money firstAmount = Money.FromDecimal(5, "EUR", _currencyLookup);
        Money secondAmount = Money.FromDecimal(5, "USD", _currencyLookup);
        
        //When
        var action = () => firstAmount.Add(secondAmount);

        //Should
        action.Should().Throw<CurrencyMismatchException>().WithMessage("Cannot add amounts from different currencies.");
    }

    [Fact]
    public void GivenMoneyWithDifferentCurrencieWhenSubstractingShouldThrow()
    {
        //Given
        Money firstAmount = Money.FromDecimal(6, "EUR", _currencyLookup);
        Money secondAmount = Money.FromDecimal(5, "USD", _currencyLookup);

        //When
        var action = () => firstAmount.Substract(secondAmount);

        //Should
        action.Should().Throw<CurrencyMismatchException>().WithMessage("Cannot substract amounts from different currencies.");
    }

    [Fact]
    public void GivenMoneyWhenToStringShouldReturn()
    {
        //Given
        Money firstAmount = Money.FromDecimal(6.58m, "EUR", _currencyLookup);

        //When
        var actual = firstAmount.ToString(); 

        //Should
        actual.Should().Be("EUR 6,58");
    }

    [Fact]
    public void GivenMoneyWithMoreDecimalsThanAllowedWhenInstanceShouldThrow()
    {
        //Given
        var action = () => Money.FromDecimal(100.58m, "JPY", _currencyLookup);

        //Should
        action.Should().Throw<TooManyDecimalsException>().WithMessage("Currency JPY cannot have more than 0 decimals.");

    }

    [Fact]
    public void GivenMoneyWithUnusedCurrencyWhenInstanceShouldThrow()
    {
        //Given
        var action = () => Money.FromDecimal(100.58m, "DEM", _currencyLookup);

        //Should
        action.Should().Throw<CurrencyNotInUseException>().WithMessage("Currency DEM is not valid");

    }

    [Fact]
    public void GivenMoneyWithUnknownCurrencyWhenInstanceShouldThrow()
    {
        //Given
        var action = () => Money.FromDecimal(100.58m, "WTF", _currencyLookup);

        //Should
        action.Should().Throw<CurrencyNotInUseException>();

    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void GivenMoneyWithNullOrWhitespaceCurrencyWhenInstanceShouldThrow(string? currencyCode)
    {
        //Given
        var action = () => Money.FromDecimal(6.58m, currencyCode, _currencyLookup);

        //Should
        action.Should().Throw<ArgumentNullException>().WithMessage("Currency must be specified (Parameter 'currencyCode')");
    }


}
