using GhostMetrics.Core.Application.Common.Data.Repositories;
using GhostMetrics.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly IApplicationDbContext Context;
    private readonly DbSet<T> _entities;

    protected Repository(IApplicationDbContext context)
    {
        Context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _entities.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        var entity = await _entities.FindAsync(id, cancellationToken);
        Guard.Against.Null(entity, nameof(entity));

        // Detach the entity from the change tracker
        _entities.Entry(entity).State = EntityState.Detached;
        return entity;
    }

    public async Task AddAsync(T obj, CancellationToken cancellationToken)
    {
        await _entities.AddAsync(obj, cancellationToken);
        await SaveAsync(cancellationToken);
    }

    public async Task UpdateAsync(T obj, CancellationToken cancellationToken)
    {
        _entities.Update(obj);
        await SaveAsync(cancellationToken);
    }

    public async Task DeleteAsync(object id, CancellationToken cancellationToken)
    {
        var existing = await _entities.FindAsync(id);
        Guard.Against.Null(existing, nameof(existing));
        _entities.Remove(existing);
        await SaveAsync(cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }
}