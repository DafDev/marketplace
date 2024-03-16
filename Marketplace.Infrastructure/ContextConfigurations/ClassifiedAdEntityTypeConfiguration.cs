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
        builder.ComplexProperty(ad => ad.Title);
        builder.ComplexProperty(ad => ad.OwnerId);
        builder.ComplexProperty(ad => ad.ApprovedBy);
        builder.ComplexProperty(ad => ad.Text);
        builder.ComplexProperty(ad => ad.Price);

        builder.Property(ad => ad.ClassifiedAdId)
            .HasConversion(classifiedAdId => classifiedAdId.Value, dbId => new ClassifiedAdId(dbId));
    }
}
