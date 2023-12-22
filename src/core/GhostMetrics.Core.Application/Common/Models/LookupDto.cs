using GhostMetrics.Core.Domain.Entities.GhostSites;

namespace GhostMetrics.Core.Application.Common.Models;

public class LookupDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GhostSiteList, LookupDto>();
            CreateMap<GhostSite, LookupDto>();
            CreateMap<GhostSiteIntegrationDetails, LookupDto>();
        }
    }
}