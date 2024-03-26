using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.User.Entities;
using Marketplace.Infrastructure.ContextConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marketplace.Infrastructure.Contexts;
public class MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options, ILoggerFactory loggerFactory) : DbContext(options)
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    public DbSet<ClassifiedAd> ClassifiedAds { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PictureEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClassifiedAdEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserProfileEntityTypeConfiguration());
    }
}
