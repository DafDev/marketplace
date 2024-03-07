using Marketplace.Domain.Contexts.Ad.DomainService;
using Marketplace.Domain.Contexts.Ad.Exceptions;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
