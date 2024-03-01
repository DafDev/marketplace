namespace Marketplace.Domain.Contexts.Ad.Events;
public abstract class DomainEvent(Guid Id)
{
    public Guid Id { get; set; } = Id;
}
