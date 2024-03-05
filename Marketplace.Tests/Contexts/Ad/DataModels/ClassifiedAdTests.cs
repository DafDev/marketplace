using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.DomainService;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Tests.Contexts.Ad.DomainServices;
using Marketplace.Domain.Contexts.Ad.Exceptions;

namespace Marketplace.Tests.Contexts.Ad.DataModels;
public class ClassifiedAdTests
{
    private readonly ICurrencyLookup _currencyLookup = new FakeCurrencyLookup();
    private readonly ClassifiedAd _classifiedAd;

    public ClassifiedAdTests() => _classifiedAd = new(id: new(Guid.NewGuid()), ownerId: new(Guid.NewGuid()));

    [Fact]
    public void GivenValidStateWhenRequestPublishShouldReturnStatePendingReview()
    {
        //Given
        _classifiedAd.SetTitle(ClassifiedAdTitle.FromString("Test title"));
        _classifiedAd.UpdateText(ClassifiedAdText.FromString("This is a great product I swear"));
        _classifiedAd.UpdatePrice(Money.FromDecimal(100.99m, "EUR", _currencyLookup));

        //When
        _classifiedAd.RequestToPublish();

        //Should
        _classifiedAd.State.Should().Be(ClassifiedAdState.PendingReview);
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
}
