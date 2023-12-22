using GhostMetrics.Core.Domain.Entities.GhostSites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.GhostSites;

public class GhostSiteConfiguration : IEntityTypeConfiguration<GhostSite>
{
    public void Configure(EntityTypeBuilder<GhostSite> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .HasOne(x => x.IntegrationDetail)
            .WithOne(x => x.GhostSite)
            .HasForeignKey<GhostSiteIntegrationDetail>(x => x.Id);
    }
}