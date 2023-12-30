using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Domain.Entities.SEO;

public class PostSeo : BaseEntity<Guid>
{
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? OgImage { get; set; }
    public string? OgTitle { get; set; }
    public string? OgDescription { get; set; }
    public string? XImage { get; set; }
    public string? XTitle { get; set; }
    public string? XDescription { get; set; }
    
    // Foreign key relationship
    public Post Post { get; set; }  = new();
    public Guid PostId { get; set; }
}