using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Tests.Contexts.Ad.ValueObjects;
public class PictureSizeTests
{

    [Fact]
    public void GivenHeightLessThanZeroWhenNewShouldThrowArgumentOutOfRangeException()
    {
        //Given
        //When
        var action = () => new PictureSize(-52,15);

        //Should
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenWidthLessThanZeroWhenNewShouldThrowArgumentOutOfRangeException()
    {
        //Given
        //When
        var action = () => new PictureSize(52, -15);

        //Should
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}
