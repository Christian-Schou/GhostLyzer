using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSite;

public class GhostSiteDto
{
    public Guid Id { get; init; }
    
    public Guid ListId { get; init; }
    
    public string? Title { get; init; }
    
    public string? Note { get; init; }
    
    public bool Paused { get; init; }
    
    public DateTime LastIndexed { get; init; }
    
    public bool Indexed { get; init; }

    public GhostSiteIntegrationDetailDto IntegrationDetail { get; init; } = new();

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Site, GhostSiteDto>();
        }
    }
}

public class GhostSiteIntegrationDetailDto
{
    public Guid Id { get; init; }
    
    public string? ApiUrl { get; init; }
    
    public string? ContentApiKey { get; init; }
    
    public string? AdminApiKey { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<IntegrationDetail, GhostSiteIntegrationDetailDto>();
        }
    }
}