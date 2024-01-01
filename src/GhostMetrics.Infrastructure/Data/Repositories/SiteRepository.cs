using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class SiteRepository : Repository<Site>, ISiteRepository
{
    private readonly ILogger<SiteRepository> _logger;
    public SiteRepository(IApplicationDbContext context,
        ILogger<SiteRepository> logger)  : base(context)
    {
        _logger = logger;
    }

    public async Task<Site> GetSiteWithIntegrationDetailsAsync(Guid siteId, CancellationToken cancellationToken)
    {
        // Retrieve site details
        var site = await Context.Sites
            .AsNoTracking()
            .Include(x => x.IntegrationDetails)
            .FirstAsync(x => x.Id == siteId, cancellationToken);

        Guard.Against.Null(site.IntegrationDetails);
        Guard.Against.Null(site);

        return site;
    }

    public async Task<string> GetSiteWebhookSecretAsync(Guid siteId, CancellationToken cancellationToken)
    {
        var site = await GetSiteWithIntegrationDetailsAsync(siteId, cancellationToken);

        Guard.Against.Null(site.IntegrationDetails);
        Guard.Against.NullOrEmpty(site.IntegrationDetails.WebhookSecret);
        
        return site.IntegrationDetails.WebhookSecret;
    }

    public async Task<string> RefreshWebhookAsync(Guid siteId, CancellationToken cancellationToken)
    {
        // Get the specific site with the integration details
        var site = await GetSiteWithIntegrationDetailsAsync(siteId, cancellationToken);
        Guard.Against.Null(site.IntegrationDetails);
        
        // Let's update the webhook secret
        site.IntegrationDetails.UpdateWebhookSecret();
        await Context.SaveChangesAsync(cancellationToken);

        // make sure the webhook secret is present and return it
        Guard.Against.NullOrEmpty(site.IntegrationDetails.WebhookSecret);
        return site.IntegrationDetails.WebhookSecret;
    }
}