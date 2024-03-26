using Marketplace.Domain.Contexts.User.Entities;
using Marketplace.Domain.Contexts.User.Repositories;
using Marketplace.Domain.Shared.ValueObjects;
using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure;
public class UserProfileRepository(MarketplaceDbContext dbContext) : IUserProfileRepository
{
    private readonly MarketplaceDbContext _dbContext = dbContext;

    public async Task Add(UserProfile entity) => await _dbContext.UserProfiles.AddAsync(entity);

    public async Task<bool> Exists(UserId id) => await _dbContext.UserProfiles.FindAsync(id) != null;

    public async Task<UserProfile> Load(UserId id) => await _dbContext.UserProfiles.FirstAsync(profile => profile.UserId == id);
}
