using Marketplace.Domain.Contexts.Ad.Events;
using Marketplace.Domain.Contexts.Ad.Exceptions;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Entities;

public class ClassifiedAd : AggregateRoot, IAggregateRoot
{
    public UserId OwnerId { get; private set; }
    public ClassifiedAdId Id { get; private set; }
    public ClassifiedAdTitle Title { get; private set; }
    public ClassifiedAdText Text { get; private set; }
    public Money Price { get; private set; }
    public UserId ApprovedBy { get; private set; }
    public ClassifiedAdState State { get; private set; }
    public List<Picture> Pictures { get; private set; } = [];
    public string AggregateId => "Ad_"+ Id.ToString();

    public ClassifiedAd(ClassifiedAdId id, UserId ownerId) => Apply(new ClassifiedAdCreatedEvent(id, ownerId));

    public void SetTitle(ClassifiedAdTitle title) => Apply(new ClassifiedAdTitleChangedEvent(Id, title));

    public void UpdateText(ClassifiedAdText text) => Apply(new ClassifiedAdTextUpdatedEvent(Id, text));

    public void UpdatePrice(Money price) => Apply(new ClassifiedAdPriceUpdatedEvent(Id, price.Amount, price.Currency.CurrencyCode, price.Currency.DecimalPlaces, price.Currency.InUse));

    public void RequestToPublish() => Apply(new ClassifiedAdSentForReviewEvent(Id));

    public void AddPicture(Uri pictureUri, PictureSize pictureSize) 
        => Apply(new PictureAddedToClassifiedAdEvent(Id, Guid.NewGuid(),pictureUri.ToString(), pictureSize.Height, pictureSize.Width, Pictures.Max(x => x.Order) + 1)); 

    protected override void EnsureValidState()
    {
        var isValid = Id is not null
             && OwnerId is not null
             && (State switch
             {
                 ClassifiedAdState.PendingReview => Title is not null
                     && Text is not null
                     && Price?.Amount > 0,
                 ClassifiedAdState.Active => Title is not null
                    && Text is not null
                    && Price?.Amount > 0
                    && ApprovedBy is not null,
                 _ => true
             });

        if (!isValid)
            throw new InvalidEntityStateException(this, $"Post-checks failed in state {State}");
    }

    protected override void OnDomainEventRaised(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case ClassifiedAdCreatedEvent @event:
                OwnerId = new(@event.OwnerId);
                Id = new(@event.AggregateRootId);
                State = ClassifiedAdState.Inactive;
                break;
            case ClassifiedAdPriceUpdatedEvent @event:
                Id = new(@event.AggregateRootId);
                Price = new(@event.Price, @event.CurrencyCode, @event.InUse, @event.DecimalPlaces);
                break;
            case ClassifiedAdTextUpdatedEvent @event:
                Id = new(@event.AggregateRootId);
                Text = new(@event.AdText);
                break;
            case ClassifiedAdTitleChangedEvent @event:
                Id = new(@event.AggregateRootId);
                Title = new(@event.Title);
                break;
            case ClassifiedAdSentForReviewEvent @event:
                Id = new(@event.AggregateRootId);
                State = ClassifiedAdState.PendingReview;
                break;
            case PictureAddedToClassifiedAdEvent @event:
                Picture picture = new(Apply);
                ApplyToEntity(picture, @event);
                Pictures.Add(picture);
                break;
            default:
                break;
        }
    }
}
