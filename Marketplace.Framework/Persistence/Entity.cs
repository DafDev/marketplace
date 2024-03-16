namespace Marketplace.Framework.Persistence;
public abstract class Entity : IInternalEventHandler
{
    private readonly Action<DomainEvent> _applier;

    protected Entity(Action<DomainEvent> applier) => _applier = applier;

    protected Entity() { }

    protected void Apply(DomainEvent domainEvent)
    {
        OnDomainEventRaised(domainEvent);
        _applier(domainEvent);
    }

    protected abstract void OnDomainEventRaised(DomainEvent domainEvent);

    void IInternalEventHandler.Handle(DomainEvent domainEvent) => OnDomainEventRaised(domainEvent);
}
