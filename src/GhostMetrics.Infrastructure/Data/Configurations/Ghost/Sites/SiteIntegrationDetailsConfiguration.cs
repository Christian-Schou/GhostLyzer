using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Sites;

public class SiteIntegrationDetailsConfiguration : IEntityTypeConfiguration<IntegrationDetail>
{
    public void Configure(EntityTypeBuilder<IntegrationDetail> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ApiUrl)
            .IsRequired();

        builder.Property(x => x.AdminApiKey)
            .IsRequired();

        builder.Property(x => x.ContentApiKey)
            .IsRequired();
    }
}