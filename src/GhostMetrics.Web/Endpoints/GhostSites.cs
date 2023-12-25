using GhostMetrics.Core.Application.Features.GhostSites.Commands.CreateGhostSite;

namespace GhostMetrics.Web.Endpoints;

public class GhostSites : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapPost(CreateGhostSite);
    }

    public async Task<Guid> CreateGhostSite(ISender sender, CreateGhostSiteCommand command)
    {
        return await sender.Send(command);
    }
}