using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly ILogger<PostRepository> _logger;
    
    public PostRepository(IApplicationDbContext context,
        ILogger<PostRepository> logger) : base(context)
    {
        _logger = logger;
    }
}