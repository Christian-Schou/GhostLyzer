using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

public class GhostSiteDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public bool Paused { get; init; }
    public bool Indexed { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Site, GhostSiteDto>();
        }
    }
}