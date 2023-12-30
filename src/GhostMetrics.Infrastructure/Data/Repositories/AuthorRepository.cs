using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    private readonly IApplicationDbContext _context;
    private DbSet<Author> _entities;
    
    public AuthorRepository(IApplicationDbContext context) : base(context)
    {
        _context = context;
        _entities = context.Authors;
    }
}