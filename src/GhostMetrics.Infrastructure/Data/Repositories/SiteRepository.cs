using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class SiteRepository : Repository<Site>, ISiteRepository
{
    private readonly IApplicationDbContext _context;
    private DbSet<Site> _entities;

    public SiteRepository(IApplicationDbContext context)  : base(context)
    {
        _context = context;
        _entities = context.Sites;
    }
}