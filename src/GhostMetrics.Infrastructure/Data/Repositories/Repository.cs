using GhostMetrics.Core.Application.Common.Data.Repositories;
using GhostMetrics.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IApplicationDbContext _context;
    private DbSet<T> _entities;

    public Repository(IApplicationDbContext context)
    {
        this._context = context;
        _entities = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _entities.ToList();
    }

    public T GetById(object id)
    {
        var entity = _entities.Find(id);
        Guard.Against.Null(entity, nameof(entity));
        return entity;
    }

    public void Insert(T obj)
    {
        _entities.Add(obj);
    }

    public void Update(T obj)
    {
        _entities.Update(obj);
    }

    public void Delete(object id)
    {
        var existing = _entities.Find(id);
        Guard.Against.Null(existing, nameof(existing));
        _entities.Remove(existing);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}