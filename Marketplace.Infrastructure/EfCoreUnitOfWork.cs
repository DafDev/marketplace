using Marketplace.Framework.Persistence;
using Marketplace.Infrastructure.Contexts;

namespace Marketplace.Infrastructure;
public class EfCoreUnitOfWork(MarketplaceDbContext dbContext) : IUnitOfWork
{
    private readonly MarketplaceDbContext _dbContext = dbContext;

    public Task Commit() => _dbContext.SaveChangesAsync();
}
