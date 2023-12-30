namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class IntegrationDetail : BaseAuditableEntity
{
    public string? ApiUrl { get; set; }
    public string? ContentApiKey { get; set; }
    public string? AdminApiKey { get; set; }

    public Guid GhostSiteId { get; set; }
    public Site Site { get; set; } = null!;
}