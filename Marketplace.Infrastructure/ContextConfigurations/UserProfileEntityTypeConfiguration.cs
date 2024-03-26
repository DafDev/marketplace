using Marketplace.Domain.Contexts.User.Entities;
using Marketplace.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.ContextConfigurations;
internal class UserProfileEntityTypeConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(profile => profile.UserId);
        builder.Property(profile => profile.UserId)
            .HasConversion(userid => userid.Value, dbId => new UserId(dbId));
        builder.OwnsOne(profile => profile.FullName);
        builder.OwnsOne(profile => profile.DisplayName);
    }
}