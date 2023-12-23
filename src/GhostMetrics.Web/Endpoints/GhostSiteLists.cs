using GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.CreateGhostSiteList;
using GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

namespace GhostMetrics.Web.Endpoints;

public class GhostSiteLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetGhostSiteLists)
            .MapPost(CreateGhostSiteList);
    }

    public async Task<GhostSitesVm> GetGhostSiteLists(ISender sender)
    {
        return await sender.Send(new GetGhostSitesQuery());
    }

    public async Task<Guid> CreateGhostSiteList(ISender sender, CreateGhostSiteListCommand command)
    {
        return await sender.Send(command);
    }
}