using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly IApplicationDbContext _context;
    private DbSet<Post> _entities;
    
    public PostRepository(IApplicationDbContext context) : base(context)
    {
        _context = context;
        _entities = context.Posts;
    }
}