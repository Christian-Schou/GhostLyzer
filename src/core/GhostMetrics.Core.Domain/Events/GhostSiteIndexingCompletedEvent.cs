using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Events;

public class GhostSiteIndexingCompletedEvent : BaseEvent
{
    public GhostSiteIndexingCompletedEvent(Site site)
    {
        Site = site;
    }
    
    public Site Site { get; }
}