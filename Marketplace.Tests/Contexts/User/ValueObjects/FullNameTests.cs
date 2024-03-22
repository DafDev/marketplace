using Marketplace.Domain.Contexts.User.ValueObjects;

namespace Marketplace.Tests.Contexts.User.ValueObjects;
public class FullNameTests
{
    [Fact]
    public void GivenNameWhenFromStringshouldReturnName()
    {
        //Given 
        var name = "Jean-Claude Belmondo";

        //When
        var fullName = FullName.FromString(name);

        //Should
        fullName.Value.Should().Be(name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenNameNullOrWhiteSpaecWhenFromStringReturnName(string name)
    {
        //When
        var action = () => FullName.FromString(name);

        //Should
        action.Should().Throw<ArgumentNullException>();
    }
}
