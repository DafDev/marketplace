
namespace Marketplace.Domain.Contexts.Ad.Events;
public class ClassifiedAdTextUpdatedEvent(Guid Id, string adText) : DomainEvent(Id)
{
    public string? AdText { get; set; } = adText;
}
