using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.User.Events;
public class UserDisplayNameUpdatedEvent(Guid userId, string displayName) : DomainEvent(userId)
{
    public string DisplayName { get; set; } = displayName;
}
