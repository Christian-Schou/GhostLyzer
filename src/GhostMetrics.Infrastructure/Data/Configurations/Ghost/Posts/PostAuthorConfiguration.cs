using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Posts;

public class PostAuthorConfiguration : IEntityTypeConfiguration<PostAuthor>
{
    public void Configure(EntityTypeBuilder<PostAuthor> builder)
    {
        builder.HasKey(pa => new { pa.PostId, pa.AuthorId });

        builder.Property(pa => pa.PostId);
        builder.Property(pa => pa.AuthorId);
        
        builder.HasOne(pa => pa.Post)
            .WithMany(p => p.PostAuthors)
            .HasForeignKey(pa => pa.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pa => pa.Author)
            .WithMany(a => a.PostAuthors)
            .HasForeignKey(pa => pa.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}