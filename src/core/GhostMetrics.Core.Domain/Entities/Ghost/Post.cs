using GhostMetrics.Core.Domain.Entities.Analytics;
using GhostMetrics.Core.Domain.Entities.SEO;

namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class Post : BaseEntity<Guid>
{
    public Guid GhostPostId { get; set; }
    public string? Title { get; set; }
    public string? Slug { get; set; }
    public string? FeaturedImagePath { get; set; }
    public bool Featured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime PublishedAt { get; set; }
    public string? Url { get; set; }
    public string? Excerpt { get; set; }
    public int ReadingTime { get; set; }
    public string? Visibility { get; set; }

    public PostSeo? Seo { get; set; }
    public PostAnalytics? Analytics { get; set; }
    public List<PostAuthor>? PostAuthors { get; set; }
    public List<PostTag>? PostTags { get; set; }
    
    // Foreign key for the Site
    public Guid SiteId { get; set; }
    public Site? Site { get; set; }
}