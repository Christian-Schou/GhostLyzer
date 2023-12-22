using GhostMetrics.Core.Domain.Entities.GhostSites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.GhostSites;

public class GhostSiteListConfiguration : IEntityTypeConfiguration<GhostSiteList>
{
    public void Configure(EntityTypeBuilder<GhostSiteList> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.OwnsOne(x => x.Color);
    }
}