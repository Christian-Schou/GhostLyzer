using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhostMetrics.Infrastructure.Data.Configurations.Ghost.Authors;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasMany(a => a.PostAuthors)
            .WithOne(pa => pa.Author)
            .HasForeignKey(pa => pa.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Analytics)
            .WithOne(an => an.Author)
            .HasForeignKey(an => an.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}