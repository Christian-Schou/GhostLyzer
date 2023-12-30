using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Sites;

public class SiteListConfiguration : IEntityTypeConfiguration<SiteList>
{
    public void Configure(EntityTypeBuilder<SiteList> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.OwnsOne(x => x.Color);
    }
}