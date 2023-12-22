namespace GhostMetrics.Core.Domain.Entities.GhostSites;

public class GhostSiteIntegrationDetails : BaseAuditableEntity
{
    public string? ApiUrl { get; set; }
    public string? ContentApiKey { get; set; }
    public string? AdminApiKey { get; set; }

    public GhostSite GhostSite { get; set; } = null!;
}