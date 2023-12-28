namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class PostTag : BaseEntity<Guid>
{
    public Guid PostId { get; set; }
    public Post? Post { get; set; }

    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}