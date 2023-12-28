using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.Analytics;

public class PostAnalytics : BaseAnalytics
{
    // Foreign key for the associated post
    public Guid PostId { get; set; }
    public Post? Post { get; set; }
}