using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

public class GhostSiteListDto
{
    public GhostSiteListDto()
    {
        Sites = Array.Empty<GhostSiteDto>();
    }
    
    public Guid Id { get; init; }

    public string? Title { get; init; }

    public string? Color { get; init; }

    public IReadOnlyCollection<GhostSiteDto> Sites { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GhostSiteList, GhostSiteListDto>()
                .ForMember(dest => dest.Sites, src => src.MapFrom(x => x.GhostSites));
        }
    }
}