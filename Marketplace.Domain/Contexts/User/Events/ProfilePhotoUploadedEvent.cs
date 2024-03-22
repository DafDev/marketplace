using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.User.Events;
public class ProfilePhotoUploadedEvent(Guid userId, string photoUrl) : DomainEvent(userId)
{
    public string PhotoUrl { get; set; } = photoUrl;
}
