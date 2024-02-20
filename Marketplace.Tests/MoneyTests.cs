using FluentAssertions;

namespace Marketplace.Tests;
public class MoneyTests
{
    [Fact]
    public void GivenMoneyObjectsWithSameAmountShouldBeEqual()
    {
        //Given
        Money firstAmount = new(5);
        Money secondAmount = new(5);

        //Should
        firstAmount.Should().Be(secondAmount);
    }

    [Fact]
    public void GivenMoneyObjectsWithDifferentAmountsShouldBeEqual()
    {
        //Given
        Money firstAmount = new(5);
        Money secondAmount = new(5);
        Money totalBanknote = new(10);
        //Should
        totalBanknote.Should().Be(secondAmount + firstAmount);
    }
}
