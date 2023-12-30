using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.Analytics;

public class TagAnalytics : BaseAnalytics
{
    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}