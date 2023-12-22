using GhostMetrics.Core.Domain.Entities.Sites;

namespace GhostMetrics.Core.Domain.Events;

public class GhostSiteIndexingCompletedEvent : BaseEvent
{
    public GhostSiteIndexingCompletedEvent(GhostSite ghostSite)
    {
        Site = ghostSite;
    }
    
    public GhostSite Site { get; }
}