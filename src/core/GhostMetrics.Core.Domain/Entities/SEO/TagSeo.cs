using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.SEO;

public class TagSeo : BaseEntity<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; } = new();
}