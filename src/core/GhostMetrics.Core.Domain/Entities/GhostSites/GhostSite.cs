namespace GhostMetrics.Core.Domain.Entities.GhostSites;

public class GhostSite : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Note { get; set; }
    public bool Paused { get; set; }
    public DateTime LastIndexed { get; set; }
    private bool _indexed;
    public bool Indexed { get => _indexed;
        set
        {
            if (value && !_indexed)
            {
                AddDomainEvent(new GhostSiteIndexingCompletedEvent(this));
            }

            _indexed = value;
        }
    }

    public GhostSiteIntegrationDetails IntegrationDetails { get; set; } = new();
    public GhostSiteList List { get; set; } = null!;
}