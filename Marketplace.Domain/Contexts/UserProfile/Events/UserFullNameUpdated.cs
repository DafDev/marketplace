using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.UserProfile.Events;
public class UserFullNameUpdated(Guid userId, string fullName) : DomainEvent(userId)
{
    public string FullName { get; set; } = fullName;
}
