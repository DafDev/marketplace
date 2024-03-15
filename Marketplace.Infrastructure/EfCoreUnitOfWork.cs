using Marketplace.Framework.Persistence;
using Marketplace.Infrastructure.Contexts;

namespace Marketplace.Infrastructure;
public class EfCoreUnitOfWork(ClassifiedAdDbContext dbContext) : IUnitOfWork
{
    private readonly ClassifiedAdDbContext _dbContext = dbContext;

    public Task Commit() => _dbContext.SaveChangesAsync();
}
