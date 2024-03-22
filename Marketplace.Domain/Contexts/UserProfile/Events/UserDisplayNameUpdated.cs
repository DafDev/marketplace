using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.UserProfile.Events;
public class UserDisplayNameUpdated(Guid userId, string displayName) : DomainEvent(userId)
{
    public string DisplayName { get; set; } = displayName;
}
