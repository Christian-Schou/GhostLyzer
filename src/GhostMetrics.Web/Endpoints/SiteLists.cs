using GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.CreateGhostSiteList;
using GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.DeleteGhostSiteList;
using GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.PurgeGhostSiteLists;
using GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.UpdateGhostSiteList;
using GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

namespace GhostMetrics.Web.Endpoints;

public class SiteLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetGhostSiteLists)
            .MapPost(CreateGhostSiteList)
            .MapPut(UpdateGhostSiteList, "{id}")
            .MapDelete(DeleteGhostSiteList, "{id}")
            .MapDelete(PurgeGhostSiteLists, "all");
    }

    public async Task<GhostSitesVm> GetGhostSiteLists(ISender sender)
    {
        return await sender.Send(new GetGhostSitesQuery());
    }

    public async Task<Guid> CreateGhostSiteList(ISender sender, CreateGhostSiteListCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> DeleteGhostSiteList(ISender sender, Guid Id)
    {
        await sender.Send(new DeleteGhostSiteListCommand(Id));
        return Results.NoContent();
    }

    public async Task<IResult> UpdateGhostSiteList(ISender sender, Guid id, UpdateGhostSiteListCommand command)
    {
        if(id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> PurgeGhostSiteLists(ISender sender)
    {
        await sender.Send(new PurgeGhostSiteListsCommand());
        return Results.NoContent();
    }
}