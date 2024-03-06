using Marketplace.Domain.Contexts.Ad.Events;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Entities;
public class Picture : Entity
{
    public Picture(Action<DomainEvent> applier) : base(applier) { }

    public PictureId Id { get; private set; }
    internal PictureSize Size { get; private set; }
    internal Uri Location { get; private set; }
    internal int Order { get; private set; }


    protected override void OnDomainEventRaised(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case PictureAddedToClassifiedAdEvent @event:
                Id = new PictureId(@event.PictureId);
                Location = new Uri(@event.Url);
                Size = new(@event.Height, @event.Width);
                Order = @event.Order;                
                break;
            default:
                break;
        }
    }
}
