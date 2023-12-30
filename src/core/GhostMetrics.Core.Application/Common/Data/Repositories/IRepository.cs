namespace GhostMetrics.Core.Application.Common.Data.Repositories;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(object id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
    Task SaveAsync(CancellationToken cancellationToken);
}