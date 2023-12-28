using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.SEO;

public class TagSeo : BaseEntity<Guid>
{
    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}