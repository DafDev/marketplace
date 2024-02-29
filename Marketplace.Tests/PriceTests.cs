using FluentAssertions;

namespace Marketplace.Tests;
public class PriceTests
{
    [Fact]
    public void GivenNegativePriceWhenInstatiateShouldThrowException()
    {
        // Given & When
        var action = () => new Price(-5);
        
        //Should
        action.Should()
            .Throw<ArgumentException>()
            .WithParameterName("Amount")
            .WithMessage("The price cannot be negative (Parameter 'Amount')");
    }
}
