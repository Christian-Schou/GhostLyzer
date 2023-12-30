using GhostMetrics.Core.Domain.Entities.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Analytics;

public class TagAnalyticsConfiguration : IEntityTypeConfiguration<TagAnalytics>
{
    public void Configure(EntityTypeBuilder<TagAnalytics> builder)
    {
        builder.HasOne(a => a.Tag)
            .WithOne(t => t.Analytics)
            .HasForeignKey<TagAnalytics>(a => a.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}