using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Common.Models;

public class LookupDto
{
    public Guid Id { get; init; }
    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SiteList, LookupDto>();
            CreateMap<Site, LookupDto>();
            CreateMap<IntegrationDetail, LookupDto>();
        }
    }
}