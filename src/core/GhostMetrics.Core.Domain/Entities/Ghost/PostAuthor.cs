namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class PostAuthor : BaseEntity<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; } = new();

    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = new();
}