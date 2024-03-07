using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdCreatedEvent(Guid id, Guid ownerId) : DomainEvent(id)
{
    public Guid OwnerId { get; set; } = ownerId;
}
