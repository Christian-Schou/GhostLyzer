using GhostMetrics.Core.Domain.Entities.Analytics;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Core.Domain.Entities.SEO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Tags;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasMany(t => t.PostTags)
            .WithOne(pt => pt.Tag)
            .HasForeignKey(pt => pt.TagId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Analytics)
            .WithOne(a => a.Tag)
            .HasForeignKey<TagAnalytics>(a => a.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Seo)
            .WithOne(s => s.Tag)
            .HasForeignKey<TagSeo>(t => t.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}