using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSite;

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