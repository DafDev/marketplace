using Marketplace.Domain.Contexts.Ad.Events;

namespace Marketplace.Domain.Contexts.Ad.Entities;
public abstract class Entity
{
    public IList<DomainEvent> DomainEvents { get; } = [];
    public void ClearEvents() => DomainEvents.Clear();

    protected void Apply(DomainEvent domainEvent)
    {
        OnDomainEventRaised(domainEvent);
        EnsureValidState();
        DomainEvents.Add(domainEvent);
    }

    protected abstract void OnDomainEventRaised(DomainEvent domainEvent);

    protected abstract void EnsureValidState();
}
