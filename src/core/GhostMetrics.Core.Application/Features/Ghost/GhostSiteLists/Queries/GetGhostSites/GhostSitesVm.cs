namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

public class GhostSitesVm
{
    public IReadOnlyCollection<GhostSiteListDto> Lists { get; init; } = Array.Empty<GhostSiteListDto>();
}