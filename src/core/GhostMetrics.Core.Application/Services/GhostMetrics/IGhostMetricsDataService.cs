namespace GhostMetrics.Core.Application.Services.GhostMetrics;

public interface IGhostMetricsDataService
{
    /// <summary>
    /// Import / Update all authors from Ghost Site into GhostMetrics database.
    /// </summary>
    /// <param name="siteId">GhostMetrics Ghost Site ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task ImportAndUpdateAuthorsForSiteAsync(Guid siteId, CancellationToken cancellationToken);

    /// <summary>
    /// Import / Update all posts from Ghost Site into GhostMetrics database.
    /// </summary>
    /// <param name="siteId">GhostMetrics Ghost Site ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task ImportAndUpdatePostsForSiteAsync(Guid siteId, CancellationToken cancellationToken);
}