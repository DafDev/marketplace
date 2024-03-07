namespace Marketplace.Framework.Persistence;
public interface IInternalEventHandler
{
    void Handle(DomainEvent domainEvent);
}
