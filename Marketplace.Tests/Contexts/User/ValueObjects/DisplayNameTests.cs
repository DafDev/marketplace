using Marketplace.Domain.Contexts.User.ValueObjects;
using Marketplace.Domain.Shared.Exceptions;
using Marketplace.Tests.Contexts.User.DomainServices;

namespace Marketplace.Tests.Contexts.User.ValueObjects;
public class DisplayNameTests
{
    private readonly ProfanityChecker _profanityChecker = new();

    [Fact]
    public void GivenNameWhenFromStringshouldReturnName()
    {
        //Given 
        var name = "JCVD";

        //When
        var displayName = DisplayName.FromString(name, _profanityChecker.Check);

        //Should
        displayName.Value.Should().Be("JCVD");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenNameNullOrWhiteSpaecWhenFromStringShouldThrow(string name)
    {
        //When
        var action = () => DisplayName.FromString(name, _profanityChecker.Check);

        //Should
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenProfanityWhenFromStringShouldThrow()
    {
        //Given 
        var name = "shit!!";
        //When
        var action = () => DisplayName.FromString(name, _profanityChecker.Check);

        //Should
        action.Should().Throw<ProfanityFoundException>();
    }
}
