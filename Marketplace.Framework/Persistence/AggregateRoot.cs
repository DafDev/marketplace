using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Framework.Persistence;
public abstract class AggregateRoot : IInternalEventHandler
{
    [NotMapped]
    public List<DomainEvent> DomainEvents { get; private set; } = [];
    public void ClearEvents() => DomainEvents.Clear();

    protected void Apply(DomainEvent domainEvent)
    {
        OnDomainEventRaised(domainEvent);
        EnsureValidState();
        DomainEvents.Add(domainEvent);
    }

    protected abstract void OnDomainEventRaised(DomainEvent domainEvent);

    protected abstract void EnsureValidState();

    protected void ApplyToEntity(IInternalEventHandler entity, DomainEvent domainEvent) => entity.Handle(domainEvent);

    void IInternalEventHandler.Handle(DomainEvent domainEvent) => OnDomainEventRaised(domainEvent);
}
