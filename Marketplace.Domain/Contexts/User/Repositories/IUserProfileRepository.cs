using Marketplace.Domain.Contexts.User.Entities;
using Marketplace.Domain.Shared.ValueObjects;

namespace Marketplace.Domain.Contexts.User.Repositories;

public interface IUserProfileRepository
{
    Task<bool> Exists(UserId id);

    Task<UserProfile> Load(UserId id);

    Task Add(UserProfile entity);
}