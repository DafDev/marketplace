using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.ContextConfigurations;

internal class ClassifiedAdEntityTypeConfiguration : IEntityTypeConfiguration<ClassifiedAd>
{
    public void Configure(EntityTypeBuilder<ClassifiedAd> builder)
    {
        builder.HasKey(ad => ad.ClassifiedAdId);
        builder.Property(ad => ad.ClassifiedAdId)
            .HasConversion(classifiedAdId => classifiedAdId.Value, dbId => new ClassifiedAdId(dbId));
        builder.OwnsOne(ad => ad.Title);
        builder.ComplexProperty(ad => ad.OwnerId);
        builder.OwnsOne(ad => ad.ApprovedBy);
        builder.OwnsOne(ad => ad.Text);
        builder.OwnsOne(ad => ad.Price).OwnsOne(price => price.Currency);

        builder.HasMany(ad => ad.Pictures)
            .WithOne()
            .HasForeignKey(pic => pic.ClassifiedAdId);
    }
}
