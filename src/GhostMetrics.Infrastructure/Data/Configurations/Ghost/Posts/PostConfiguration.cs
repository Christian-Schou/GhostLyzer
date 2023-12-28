using System.IO.Compression;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Core.Domain.Entities.SEO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Posts;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(p => p.Site)
            .WithMany(s => s.Posts)
            .HasForeignKey(p => p.SiteId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(p => p.Analytics)
            .WithOne(pa => pa.Post)
            .HasForeignKey(pa => pa.PostId);

        builder.HasOne(p => p.Seo)
            .WithOne(seo => seo.Post)
            .HasForeignKey<PostSeo>(seo => seo.PostId);

        builder.HasMany(p => p.PostAuthors)
            .WithOne(pa => pa.Post)
            .HasForeignKey(pa => pa.PostId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}