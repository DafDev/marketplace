using Marketplace.Domain.Contexts.Ad.Events;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Entities;
public class Picture : Entity
{
    public Picture(Action<DomainEvent> applier) : base(applier) { }
    protected Picture() :base() { }

    public ClassifiedAdId ClassifiedAdId { get; private set; }
    public PictureId PictureId { get; private set; }
    public PictureSize Size { get; private set; }
    public Uri Location { get; private set; }
    public int Order { get; private set; }

    internal void Resize(PictureSize newSize, ClassifiedAdId classifiedAdId) => Apply(new ClassifiedAdPictureResizedEvent(classifiedAdId, PictureId, newSize));

    protected override void OnDomainEventRaised(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case PictureAddedToClassifiedAdEvent @event:
                ClassifiedAdId = new ClassifiedAdId(@event.AggregateRootId);
                PictureId = new PictureId(@event.PictureId);
                Location = new Uri(@event.Url);
                Size = new(@event.Height, @event.Width);
                Order = @event.Order;                
                break;
            case ClassifiedAdPictureResizedEvent @event:
                Size = new(@event.Height, @event.Width);
                break;
            default:
                break;
        }
    }
}
