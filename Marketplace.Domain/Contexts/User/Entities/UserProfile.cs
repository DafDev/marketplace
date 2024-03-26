using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.User.Events;
using Marketplace.Domain.Contexts.User.ValueObjects;
using Marketplace.Domain.Shared.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Domain.Contexts.User.Entities;
public class UserProfile : AggregateRoot, IAggregateRoot
{
    #region Properties
    public UserId UserId { get; private set; }
    public FullName FullName { get; private set; }
    public DisplayName DisplayName { get; private set; }
    public string? PhotoUrl { get; private set; } = string.Empty;
    public string AggregateId => "User_" + UserId.ToString();
    #endregion

    public UserProfile(UserId userId, FullName fullName, DisplayName displayName) => Apply(new UserRegisteredEvent(userId, fullName, displayName));
    protected UserProfile() { }


    #region Public Methods
    public void UpdateFullName(FullName fullName) => Apply(new UserFullNameUpdatedEvent(UserId, fullName));
    public void UpdateDisplayName(DisplayName displayName) => Apply(new UserDisplayNameUpdatedEvent(UserId, displayName));
    public void UpdateProfilePhoto(Uri photoUrl) => Apply(new ProfilePhotoUploadedEvent(UserId, photoUrl.ToString()));
    #endregion

    protected override void EnsureValidState()
    {
    }

    protected override void OnDomainEventRaised(DomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case UserRegisteredEvent @event:
                UserId = new(@event.AggregateRootId);
                FullName = new(@event.FullName);
                DisplayName = new(@event.DisplayName);
                break;
            case UserFullNameUpdatedEvent @event:
                FullName = new(@event.FullName);
                break;
            case UserDisplayNameUpdatedEvent @event:
                DisplayName = new(@event.DisplayName);
                break;
            case ProfilePhotoUploadedEvent @event:
                PhotoUrl = @event.PhotoUrl;
                break;
            default:
                break;
        }
    }
}
