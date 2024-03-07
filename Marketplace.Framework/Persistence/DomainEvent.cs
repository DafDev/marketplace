namespace Marketplace.Framework.Persistence;
public abstract class DomainEvent(Guid aggregateRootId)
{
    public Guid AggregateRootId { get; set; } = aggregateRootId;
}
