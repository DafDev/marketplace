using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Tests.Contexts.Ad.DomainServices;
using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.ValueObjects;
using Marketplace.Domain.Shared.Exceptions;

namespace Marketplace.Tests.Contexts.Ad.DataModels;
public class ClassifiedAdTests
{
    private readonly ICurrencyLookup _currencyLookup = new FakeCurrencyLookup();
    private readonly ClassifiedAd _classifiedAd;

    public ClassifiedAdTests() => _classifiedAd = new(classifiedAdId: new(Guid.NewGuid()), ownerId: new(Guid.NewGuid()));

    [Fact]
    public void GivenValidStateWhenRequestPublishShouldReturnStatePendingReview()
    {
        //Given
        _classifiedAd.AddPicture(new Uri("http://tumblr.com"), new PictureSize(900,1200));
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(100.99m, "EUR", _currencyLookup));

        //When
        _classifiedAd.RequestToPublish();

        //Should
        _classifiedAd.State.Should().Be(ClassifiedAdState.PendingReview);
    }


    [Fact]
    public void GivenInvalidFirstPictureWhenRequestPublishShouldThrow()
    {
        //Given
        _classifiedAd.AddPicture(new Uri("http://tumblr.com"), new PictureSize(900, 200));
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(100.99m, "EUR", _currencyLookup));

        //When
        var action = () => _classifiedAd.RequestToPublish();

        //Should
        action.Should().ThrowExactly<InvalidEntityStateException>();
    }



    [Fact]
    public void GivenNoTitleWhenRequestPublishShouldThrow()
    {
        //Given
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(100.99m, "EUR", _currencyLookup));

        //When
        var action = () => _classifiedAd.RequestToPublish();

        //Should
        action.Should().ThrowExactly<InvalidEntityStateException>();
    }

    [Fact]
    public void GivenNoTextWhenRequestPublishShouldThrow()
    {
        //Given
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(100.99m, "EUR", _currencyLookup));

        //When
        var action = () => _classifiedAd.RequestToPublish();

        //Should
        action.Should().ThrowExactly<InvalidEntityStateException>();
    }

    [Fact]
    public void GivenEmptyNoPriceWhenRequestPublishShouldThrow()
    {
        //Given
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));

        //When
        var action = () => _classifiedAd.RequestToPublish();

        //Should
        action.Should().ThrowExactly<InvalidEntityStateException>();
    }

    [Fact]
    public void GivenPriceAmounntIsZeroWhenRequestPublishShouldThrow()
    {
        //Given
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(0.0m, "EUR", _currencyLookup));

        //When
        var action = () => _classifiedAd.RequestToPublish();

        //Should
        action.Should().ThrowExactly<InvalidEntityStateException>();
    }

    [Fact]
    public void GivenValidSizeWhenResizePictureShouldReturn()
    {
        //Given
        _classifiedAd.AddPicture(new Uri("http://tumblr.com"), new PictureSize(900, 1200));
        PictureSize newSize = new(2500, 1700);

        //When
        _classifiedAd.ResizePicture(_classifiedAd.Pictures.First().PictureId, newSize);

        //Should
        _classifiedAd.Pictures.First().Size.Should().Be(newSize);
    }

    [Fact]
    public void GivenInValidSizeWhenResizePictureShouldThrow()
    {
        //Given
        PictureSize newSize = new(500, 700);

        //When
        var action = () => _classifiedAd.ResizePicture(new PictureId(Guid.NewGuid()), newSize) ;

        //Should
        action.Should().ThrowExactly<InvalidOperationException>();

    }
}
