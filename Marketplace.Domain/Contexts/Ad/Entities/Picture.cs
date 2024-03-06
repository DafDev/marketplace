using Marketplace.Domain.Contexts.Ad.Events;
using Marketplace.Domain.Contexts.Ad.ValueObjects;

namespace Marketplace.Domain.Contexts.Ad.Entities;
public class Picture : Entity
{
    public PictureId Id { get; set; }
    internal PictureSize Size { get; set; } 
    internal Uri Location { get; set; }
    internal int Order { get; set; }

    protected override void EnsureValidState() { }

    protected override void OnDomainEventRaised(DomainEvent domainEvent) { }
}
