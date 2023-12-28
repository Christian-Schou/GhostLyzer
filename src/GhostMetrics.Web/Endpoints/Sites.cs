using GhostMetrics.Core.Application.Common.Models;
using GhostMetrics.Core.Application.Features.GhostSites.Commands.CreateGhostSite;
using GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSite;
using GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSitesWithPagination;

namespace GhostMetrics.Web.Endpoints;

public class Sites : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetGhostSites)
            .MapGet(GetGhostSite, "{id}")
            .MapPost(CreateGhostSite);
    }

    public async Task<GhostSiteDto> GetGhostSite(ISender sender, Guid id)
    {
        return await sender.Send(new GetGhostSiteQuery(id));
    }

    public async Task<PaginatedList<GhsotSiteBriefDto>> GetGhostSites(ISender sender, [AsParameters] GetGhostSitesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<Guid> CreateGhostSite(ISender sender, CreateGhostSiteCommand command)
    {
        return await sender.Send(command);
    }
}