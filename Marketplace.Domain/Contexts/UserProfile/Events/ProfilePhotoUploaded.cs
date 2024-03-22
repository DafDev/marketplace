using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.UserProfile.Events;
public class ProfilePhotoUploaded(Guid userId, string photoUrl) : DomainEvent(userId)
{
    public string PhotoUrl { get; set;  } = photoUrl;
}
