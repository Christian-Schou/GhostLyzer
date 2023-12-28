using GhostMetrics.Core.Domain.Entities.Analytics;

namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class Author : BaseEntity<Guid>
{
    public string? GhostAuthorId { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? ProfileImage { get; set; }
    public string? Bio { get; set; }
    public string? Url { get; set; }
    public List<PostAuthor> PostAuthors { get; set; } = new();
    public List<AuthorAnalytics>? Analytics { get; set; }
}