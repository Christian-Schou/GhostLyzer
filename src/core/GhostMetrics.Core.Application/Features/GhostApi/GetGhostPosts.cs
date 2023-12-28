using GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSite;
using GhostMetrics.Core.Application.Services.Ghost;
using GhostSharp.Entities;

namespace GhostMetrics.Core.Application.Features.GhostApi;

public record GetGhostPostsQuery(Guid SiteId) : IRequest<List<Post>>;

public class GetGhostPostsQueryHandler : IRequestHandler<GetGhostPostsQuery, List<Post>>
{
    private readonly IGhostApiService _ghostApi;
    private readonly ISender _sender;
    
    public GetGhostPostsQueryHandler(ISender sender, IGhostApiService ghostApi)
    {
        _sender = sender;
        _ghostApi = ghostApi;
    }

    public async Task<List<Post>> Handle(GetGhostPostsQuery request, CancellationToken cancellationToken)
    {
        var ghostSiteEntity = await _sender.Send(new GetGhostSiteQuery(request.SiteId), cancellationToken);
        
        return _ghostApi.GetAllGhostPosts(
            apiUrl: ghostSiteEntity.IntegrationDetails.ApiUrl!,
            contentApiKey: ghostSiteEntity.IntegrationDetails.ContentApiKey!);
    }
}