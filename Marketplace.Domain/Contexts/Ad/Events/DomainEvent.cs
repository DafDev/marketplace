namespace Marketplace.Domain.Contexts.Ad.Events;
public abstract class DomainEvent(Guid aggregateRootId)
{
    public Guid AggregateRootId { get; set; } = aggregateRootId;
}
