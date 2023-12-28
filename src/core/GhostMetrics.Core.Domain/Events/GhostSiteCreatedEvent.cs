using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Events;

public class GhostSiteCreatedEvent : BaseEvent
{
    public GhostSiteCreatedEvent(Site site)
    {
        Site = site;
    }

    public Site Site { get; }
}