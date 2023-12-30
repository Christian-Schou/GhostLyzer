using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Sites;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .HasOne(x => x.IntegrationDetails)
            .WithOne(x => x.Site)
            .HasForeignKey<IntegrationDetail>(x => x.Id);
        
        builder.HasMany(s => s.Posts)
            .WithOne(p => p.Site)
            .HasForeignKey(p => p.SiteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}