using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Domain.Events;

public class GhostSiteCreatedEvent : BaseEvent
{
    public GhostSiteCreatedEvent(GhostSite ghostSite)
    {
        GhostSite = ghostSite;
    }

    public GhostSite GhostSite { get; }
}