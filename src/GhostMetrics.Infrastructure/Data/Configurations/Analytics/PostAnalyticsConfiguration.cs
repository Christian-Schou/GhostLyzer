using GhostMetrics.Core.Domain.Entities.Analytics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Analytics;

public class PostAnalyticsConfiguration : IEntityTypeConfiguration<PostAnalytics>
{
    public void Configure(EntityTypeBuilder<PostAnalytics> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(pa => pa.Post)
            .WithMany(p => p.Analytics)
            .HasForeignKey(pa => pa.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}