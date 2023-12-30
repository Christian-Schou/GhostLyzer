using GhostMetrics.Core.Domain.Entities.Analytics;
using GhostMetrics.Core.Domain.Entities.SEO;

namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class Tag : BaseEntity<Guid>
{
    public string? GhostTagId { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? FeaturedImage { get; set; }
    
    public List<PostTag>? PostTags { get; set; }
    public TagSeo? Seo { get; set; }
    public TagAnalytics? Analytics { get; set; }
}