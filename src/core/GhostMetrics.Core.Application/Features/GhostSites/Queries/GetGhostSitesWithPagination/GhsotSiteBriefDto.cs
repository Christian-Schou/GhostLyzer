using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSitesWithPagination;

public class GhsotSiteBriefDto
{
    public Guid Id { get; init; }
    public Guid ListId { get; init; }
    public string? Title { get; init; }
    public bool Indexed { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GhostSite, GhsotSiteBriefDto>();
        }
    }
}