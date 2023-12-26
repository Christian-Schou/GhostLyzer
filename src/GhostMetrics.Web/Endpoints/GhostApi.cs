using GhostMetrics.Core.Application.Features.GhostApi;
using GhostMetrics.Core.Domain.Models.GhostCms.Content;

namespace GhostMetrics.Web.Endpoints;

public class GhostApi : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetGhostPosts, "{siteId}");
    }

    public async Task<List<GhostApiPost>> GetGhostPosts(ISender sender, Guid siteId)
    {
        return await sender.Send(new GetGhostPostsQuery(siteId));
    }
}