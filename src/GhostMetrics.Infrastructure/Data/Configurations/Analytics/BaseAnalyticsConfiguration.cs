using GhostMetrics.Core.Domain.Entities.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Analytics;

public class BaseAnalyticsConfiguration : IEntityTypeConfiguration<BaseAnalytics>
{
    public void Configure(EntityTypeBuilder<BaseAnalytics> builder)
    {
        builder.HasMany(analytics => analytics.Data)
            .WithOne(data => data.BaseAnalytics)
            .HasForeignKey(data => data.BaseAnalyticsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}