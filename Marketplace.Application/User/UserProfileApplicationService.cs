using Marketplace.Application.Shared.Services;
using Marketplace.Application.User.Contracts.V1;
using Marketplace.Domain.Contexts.User.Entities;
using Marketplace.Domain.Contexts.User.Repositories;
using Marketplace.Domain.Contexts.User.ValueObjects;
using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Application.User;
public class UserProfileApplicationService(IUserProfileRepository repository, IUnitOfWork unitOfWork, IContentModeration contentModeration) : IApplicationService<UserContract>
{
    private readonly IUserProfileRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IContentModeration _contentModeration = contentModeration;

    public async Task Handle(UserContract command)
    {
        switch (command)
        {
            case RegisterUser cmd:
                await HandleCreate(cmd);
                break;
            case UpdateUserFullName cmd:
                await HandleUpdate(cmd.UserId,profile => profile.UpdateFullName(FullName.FromString(cmd.FullName)));
                break;
            case UpdateUserDisplayName cmd:
                await HandleUpdate(cmd.UserId, async profile => profile.UpdateDisplayName(await DisplayName.FromString(cmd.DisplayName, _contentModeration)));
                break;
                case UpdateUserProfilePhoto cmd:
                await HandleUpdate(cmd.UserId, profile => profile.UpdateProfilePhoto(new Uri(cmd.PhotoUrl)));
                break;
            default:
                throw new InvalidOperationException($"Command of type {command.GetType().FullName} does not exist.");
        }
    }

    private async Task HandleCreate(RegisterUser cmd)
    {
        if (await _repository.Exists(new(cmd.UserId)))
            throw new InvalidOperationException($"Entity with id {cmd.UserId} already exists.");

        UserProfile userProfile = new(new UserId(cmd.UserId),
            FullName.FromString(cmd.FullName),
            await DisplayName.FromString(cmd.DisplayName, _contentModeration));
        await _repository.Add(userProfile);
        await _unitOfWork.Commit();
    }
   
    private async Task<UserProfile> GetUserProfile(Guid userProfileId)
        => await _repository.Load(new(userProfileId)) ?? throw new InvalidOperationException($"Entity with id {userProfileId} does not exists.");

    private async Task HandleUpdate(Guid userProfileId, Action<UserProfile> action)
    {
        var userProfile = await GetUserProfile(userProfileId);
        action(userProfile);
        await _unitOfWork.Commit();
    }

}
