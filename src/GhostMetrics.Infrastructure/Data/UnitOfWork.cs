using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;

namespace GhostMetrics.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;
    
    public IAuthorRepository Authors { get; private set; }
    public IPostRepository Posts { get; private set; }
    public ISiteRepository Sites { get; private set; }

    public UnitOfWork(
        IApplicationDbContext context,
        IAuthorRepository authors,
        IPostRepository posts,
        ISiteRepository sites)
    {
        _context = context;
        Authors = authors;
        Posts = posts;
        Sites = sites;
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}