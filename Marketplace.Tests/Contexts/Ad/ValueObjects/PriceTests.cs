using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Tests.Contexts.Ad.DomainServices;

namespace Marketplace.Tests.Contexts.Ad.ValueObjects;
public class PriceTests
{
    [Fact]
    public void GivenNegativePriceWhenInstatiateShouldThrowException()
    {
        // Given & When
        var action = () => new Price(-5, "EUR", new FakeCurrencyLookup());

        //Should
        action.Should()
            .Throw<ArgumentException>()
            .WithParameterName("Amount")
            .WithMessage("The price cannot be negative (Parameter 'Amount')");
    }
}
