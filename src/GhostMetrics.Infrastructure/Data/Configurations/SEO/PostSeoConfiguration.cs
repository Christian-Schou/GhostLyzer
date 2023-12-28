using GhostMetrics.Core.Domain.Entities.SEO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.SEO;

public class PostSeoConfiguration : IEntityTypeConfiguration<PostSeo>
{
    public void Configure(EntityTypeBuilder<PostSeo> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(pa => pa.Post)
            .WithOne(p => p.Seo)
            .HasForeignKey<PostSeo>(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}