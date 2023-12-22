using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Domain.Events;

public class GhostSiteIndexingCompletedEvent : BaseEvent
{
    public GhostSiteIndexingCompletedEvent(GhostSite ghostSite)
    {
        Site = ghostSite;
    }
    
    public GhostSite Site { get; }
}