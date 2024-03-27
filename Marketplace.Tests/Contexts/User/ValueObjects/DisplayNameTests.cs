using Marketplace.Domain.Contexts.User.ValueObjects;
using Marketplace.Domain.Shared.Exceptions;
using Marketplace.Tests.Contexts.User.DomainServices;
using System.Runtime.CompilerServices;

namespace Marketplace.Tests.Contexts.User.ValueObjects;
public class DisplayNameTests
{
    private readonly ProfanityChecker _profanityChecker = new();

    [Fact]
    public async Task GivenNameWhenFromStringshouldReturnName()
    {
        //Given 
        var name = "JCVD";

        //When
        var displayName = await DisplayName.FromString(name, _profanityChecker);

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
        var action = () => DisplayName.FromString(name, _profanityChecker);

        //Should
        action.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public void GivenProfanityWhenFromStringShouldThrow()
    {
        //Given 
        var name = "shit!!";
        //When
        var action = () => DisplayName.FromString(name, _profanityChecker);

        //Should
        action.Should().ThrowAsync<ProfanityFoundException>();
    }
}
