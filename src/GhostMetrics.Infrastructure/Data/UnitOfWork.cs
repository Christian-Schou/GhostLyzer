using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Infrastructure.Data.Repositories;

namespace GhostMetrics.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _context;
    
    public IAuthorRepository Authors { get; private set; }
    public IPostRepository Posts { get; private set; }
    public ISiteRepository Sites { get; private set; }

    public UnitOfWork(IApplicationDbContext context)
    {
        _context = context;
        Authors = new AuthorRepository(_context);
        Posts = new PostRepository(_context);
        Sites = new SiteRepository(_context);
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}