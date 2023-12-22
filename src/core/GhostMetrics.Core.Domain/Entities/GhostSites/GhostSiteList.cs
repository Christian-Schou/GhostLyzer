namespace GhostMetrics.Core.Domain.Entities.GhostSites;

public class GhostSiteList : BaseAuditableEntity
{
    public string? Title { get; set; }
    public Color Color { get; set; } = Color.White;
    public IList<GhostSite> GhostSites { get; private set; } = new List<GhostSite>();
}