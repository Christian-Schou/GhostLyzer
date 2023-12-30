namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService
{
    public async Task ImportAndUpdateAuthorsForSiteAsync(Guid siteId, CancellationToken cancellationToken)
    {
        try
        {
            // Get the site and make sure we have the required integration details
            var site = await _unitOfWork.Sites.GetSiteWithIntegrationDetailsAsync(siteId, cancellationToken);
            Guard.Against.NullOrEmpty(site.IntegrationDetails.ApiUrl);
            Guard.Against.NullOrEmpty(site.IntegrationDetails.ContentApiKey);
            
            // Get all authors from the Ghost Site
            var authors = _ghostApi
                .GetAllAuthors(site.IntegrationDetails.ApiUrl, site.IntegrationDetails.ContentApiKey);

            foreach (var author in authors)
            {
                await _unitOfWork.Authors.AddOrUpdateAuthorAsync(author, cancellationToken);
            }
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "GhostMetrics: An unhandled error occured while trying to add or update all authors from Ghost site to GhostMetrics database");
            throw;
        }
    }

}