using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdTitleChangedEvent(Guid id, string title) : DomainEvent(id)
{
    public string Title { get; set; } = title;
}
