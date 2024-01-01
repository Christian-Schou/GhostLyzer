using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSite;

public class SiteDto
{
    public Guid Id { get; init; }
    
    public Guid ListId { get; init; }
    
    public string? Title { get; init; }
    
    public string? Note { get; init; }
    
    public bool Paused { get; init; }
    
    public DateTime LastIndexed { get; init; }
    
    public bool Indexed { get; init; }

    public GhostSiteIntegrationDetailDto IntegrationDetails { get; init; } = new();

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Site, SiteDto>();
        }
    }
}