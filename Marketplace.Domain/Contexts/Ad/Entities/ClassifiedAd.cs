
using Marketplace.Domain.Contexts.Ad.Events;
using Marketplace.Domain.Contexts.Ad.Exceptions;
using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Domain.Contexts.Ad.Entities;

public class ClassifiedAd : Entity
{
    public UserId OwnerId { get; }
    public ClassifiedAdId Id { get; }
    public ClassifiedAdTitle Title { get; private set; }
    public ClassifiedAdText Text { get; private set; }
    public Money Price { get; private set; }
    public UserId ApprovedBy { get; private set; }
    public ClassifiedAdState State { get; private set; }

    public ClassifiedAd(UserId ownerId, ClassifiedAdId id)
    {
        OwnerId = ownerId;
        Id = id;
        State = ClassifiedAdState.Inactive;
        EnsureValidState();
        DomainEvents.Add(new ClassifiedAdCreatedEvent(Id.Value, OwnerId.Value));
    }

    public void SetTitle(ClassifiedAdTitle title)
    {
        Title = title;
        EnsureValidState();
        DomainEvents.Add(new ClassifiedAdTitleChangedEvent(Id.Value, Title.Title));
    }

    public void UpdateText(ClassifiedAdText text)
    {
        Text = text;
        EnsureValidState();
        DomainEvents.Add(new ClassifiedAdTextUpdatedEvent(Id.Value, Text.Value));
    }

    public void UpdatePrice(Money price)
    {
        Price = price;
        EnsureValidState();
        DomainEvents.Add(new ClassifiedAdPriceUpdatedEvent(Id.Value, Price.Amount, Price.Currency.CurrencyCode));
    }

    public void RequestToPublish()
    {
        State = ClassifiedAdState.PendingReview;
        EnsureValidState();
        DomainEvents.Add(new ClassifiedAdSentForReviewEvent(Id.Value));
    }

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
        throw new NotImplementedException();
    }
}
