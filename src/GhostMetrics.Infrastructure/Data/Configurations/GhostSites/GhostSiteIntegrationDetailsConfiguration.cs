using GhostMetrics.Core.Domain.Entities.GhostSites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.GhostSites;

public class GhostSiteIntegrationDetailsConfiguration : IEntityTypeConfiguration<GhostSiteIntegrationDetail>
{
    public void Configure(EntityTypeBuilder<GhostSiteIntegrationDetail> builder)
    {
        builder.Property(x => x.ApiUrl)
            .IsRequired();

        builder.Property(x => x.AdminApiKey)
            .IsRequired();

        builder.Property(x => x.ContentApiKey)
            .IsRequired();
    }
}