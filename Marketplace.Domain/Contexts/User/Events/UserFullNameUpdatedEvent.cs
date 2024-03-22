using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.User.Events;
public class UserFullNameUpdatedEvent(Guid userId, string fullName) : DomainEvent(userId)
{
    public string FullName { get; set; } = fullName;
}
