using GhostMetrics.Core.Application.Common.Models;
using GhostMetrics.Core.Application.Features.Ghost.Sites.Commands.CreateGhostSite;
using GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSite;
using GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSitesWithPagination;

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

    public async Task<SiteDto> GetGhostSite(ISender sender, Guid id)
    {
        return await sender.Send(new GetGhostSiteQuery(id));
    }

    public async Task<PaginatedList<BriefSiteDto>> GetGhostSites(ISender sender, [AsParameters] GetGhostSitesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<Guid> CreateGhostSite(ISender sender, CreateGhostSiteCommand command)
    {
        return await sender.Send(command);
    }
}