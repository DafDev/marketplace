using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.UserProfile.Events;
public class UserRegistered(Guid userId, string fullName, string displayName) : DomainEvent(userId)
{
    public string FullName { get; set; } = fullName;
    public string DisplayName { get; set; } = displayName;
}
