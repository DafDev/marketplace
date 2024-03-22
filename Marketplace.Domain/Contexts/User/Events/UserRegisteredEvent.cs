using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.User.Events;
public class UserRegisteredEvent(Guid userId, string fullName, string displayName) : DomainEvent(userId)
{
    public string FullName { get; set; } = fullName;
    public string DisplayName { get; set; } = displayName;
}
