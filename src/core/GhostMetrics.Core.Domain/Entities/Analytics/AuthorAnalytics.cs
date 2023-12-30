using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.Analytics;

public class AuthorAnalytics : BaseAnalytics
{
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
}