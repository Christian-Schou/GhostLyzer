using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<GhostSiteList> GhostSiteLists { get; }

	DbSet<GhostSite> GhostSites { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}