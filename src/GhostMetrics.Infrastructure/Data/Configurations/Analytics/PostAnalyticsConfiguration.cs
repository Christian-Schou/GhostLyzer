using GhostMetrics.Core.Domain.Entities.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Analytics;

public class PostAnalyticsConfiguration : IEntityTypeConfiguration<PostAnalytics>
{
    public void Configure(EntityTypeBuilder<PostAnalytics> builder)
    {
        builder.HasOne(pa => pa.Post)
            .WithOne(p => p.Analytics)
            .HasForeignKey<PostAnalytics>(pa => pa.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}