using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.Repositories;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure;

public class ClassifiedAdRepository(ClassifiedAdDbContext dbContext) : IClassifiedAdRepository
{
    private readonly ClassifiedAdDbContext _dbContext = dbContext;
    public async Task Add(ClassifiedAd entity) => await _dbContext.ClassifiedAds.AddAsync(entity);
    public async Task<bool> Exists(ClassifiedAdId id) => await _dbContext.ClassifiedAds.FindAsync(id) != null;
    public async Task<ClassifiedAd> Load(ClassifiedAdId id) 
        => await _dbContext
        .ClassifiedAds
        .Include(ad => ad.Pictures)
        .FirstAsync(ad => ad.ClassifiedAdId == id);
}
