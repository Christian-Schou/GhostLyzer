using GhostMetrics.Core.Application.Common.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Data.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    /// <summary>
    /// Adds a new author or updates an existing one in the database asynchronously.
    /// </summary>
    /// <param name="ghostAuthor">The author information from Ghost to add or update in the database.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the work.</param>
    /// <returns>The ID of the added or updated author.</returns>
    /// <exception cref="Exception">Throws an exception if an error occurs while adding or updating the author.
    /// This is handled by the global exception handling.</exception>
    public Task<Guid> AddOrUpdateAuthorAsync(GhostSharp.Entities.Author ghostAuthor,
        CancellationToken cancellationToken);
}