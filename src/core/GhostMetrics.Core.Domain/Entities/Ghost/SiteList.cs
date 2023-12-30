namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class SiteList : BaseAuditableEntity
{
    public string? Title { get; set; }
    public Color Color { get; set; } = Color.White;
    public IList<Site> GhostSites { get; private set; } = new List<Site>();
}