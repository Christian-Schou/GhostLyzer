namespace GhostMetrics.Core.Application.Common.Data.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(object id, CancellationToken cancellationToken);
    Task AddAsync(T obj, CancellationToken cancellationToken);
    Task UpdateAsync(T obj, CancellationToken cancellationToken);
    Task DeleteAsync(object id, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}