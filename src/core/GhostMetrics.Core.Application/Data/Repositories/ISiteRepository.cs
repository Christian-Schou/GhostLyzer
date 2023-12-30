using GhostMetrics.Core.Application.Common.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Data.Repositories;

public interface ISiteRepository : IRepository<Site>
{
    public Task<Site> GetSiteWithIntegrationDetailsAsync(Guid siteId, CancellationToken cancellationToken);
}