using GhostMetrics.Core.Application.Data.Repositories;

namespace GhostMetrics.Core.Application.Common.Data;

public interface IUnitOfWork
{
    IAuthorRepository Authors { get; }
    IPostRepository Posts { get; }
    ISiteRepository Sites { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken);
}