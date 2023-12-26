using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSite;
using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Core.Domain.Models.GhostCms.Content;

namespace GhostMetrics.Core.Application.Features.GhostApi;

public record GetGhostPostsQuery(Guid SiteId) : IRequest<List<GhostApiPost>>;

public class GetGhostPostsQueryHandler : IRequestHandler<GetGhostPostsQuery, List<GhostApiPost>>
{
    private readonly IGhostApiService _ghostApi;
    private readonly ISender _sender;
    
    public GetGhostPostsQueryHandler(ISender sender, IGhostApiService ghostApi)
    {
        _sender = sender;
        _ghostApi = ghostApi;
    }

    public async Task<List<GhostApiPost>> Handle(GetGhostPostsQuery request, CancellationToken cancellationToken)
    {
        var ghostSiteEntity = await _sender.Send(new GetGhostSiteQuery(request.SiteId), cancellationToken);
        
        return await _ghostApi.GetAllGhostPostsAsync(
            apiUrl: ghostSiteEntity.IntegrationDetail.ApiUrl!,
            contentApiKey: ghostSiteEntity.IntegrationDetail.ContentApiKey!);
    }
}