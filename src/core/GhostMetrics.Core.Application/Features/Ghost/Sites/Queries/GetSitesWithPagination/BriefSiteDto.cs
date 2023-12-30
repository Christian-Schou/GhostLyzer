using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSitesWithPagination;

public class BriefSiteDto
{
    public Guid Id { get; init; }
    public Guid ListId { get; init; }
    public string? Title { get; init; }
    public bool Indexed { get; init; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Site, BriefSiteDto>();
        }
    }
}