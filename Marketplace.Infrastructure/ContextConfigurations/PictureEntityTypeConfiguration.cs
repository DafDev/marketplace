using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.ContextConfigurations;
internal class PictureEntityTypeConfiguration : IEntityTypeConfiguration<Picture>
{
    public void Configure(EntityTypeBuilder<Picture> builder)
    {
        builder.HasKey(pic => pic.PictureId);
        builder.Property(pic => pic.PictureId)
            .HasConversion(pictureId => pictureId.Value, dbId => new PictureId(dbId));
        builder.ComplexProperty(pic => pic.Size);
    }
}
