using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<SiteList> SiteLists { get; }

	DbSet<Site> Sites { get; }
    
    DbSet<Post> Posts { get; }
    
    DbSet<Author> Authors { get; }
    
    DbSet<PostAuthor> PostAuthors { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    DbSet<T> Set<T>() where T : class;
}