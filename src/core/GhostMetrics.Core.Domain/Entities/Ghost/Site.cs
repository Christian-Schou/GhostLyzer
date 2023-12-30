namespace GhostMetrics.Core.Domain.Entities.Ghost;

public class Site : BaseAuditableEntity
{
    /// <summary>
    /// Ghost Site Title.
    /// </summary>
    public string? Title { get; set; }
    
    /// <summary>
    /// Personal notes for the site in Ghost Metrics.
    /// </summary>
    public string Note { get; set; } = string.Empty;
    
    /// <summary>
    /// Ghost Site Description.
    /// </summary>
    /// <remarks>
    /// The site description is gathered from the Ghost API.
    /// </remarks>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// A boolean to check if this Ghost site has been paused
    /// for indexing.
    /// </summary>
    public bool Paused { get; set; }
    
    /// <summary>
    /// When was this ghost site last indexed in the Ghost Metrics system.
    /// </summary>
    public DateTime LastIndexed { get; set; }
    
    private bool _indexed;
    
    /// <summary>
    /// A boolean to tell if this site has been indexed yet.
    /// </summary>
    public bool Indexed { get => _indexed;
        set
        {
            if (value && !_indexed)
            {
                AddDomainEvent(new GhostSiteIndexingCompletedEvent(this));
            }

            _indexed = value;
        }
    }

    /// <summary>
    /// Integration details for Ghost Metrics
    /// to communicate with the Ghost Admin/Content API.
    /// </summary>
    public IntegrationDetail IntegrationDetails { get; set; } = new();
    
    /// <summary>
    /// Posts that are related to this Ghost site.
    /// </summary>
    public List<Post> Posts { get; set; } = new();
    
    /// <summary>
    /// What list the Ghost Site belongs to in Ghost Metrics
    /// </summary>
    public Guid ListId { get; set; }
    public SiteList List { get; set; } = null!;
}