using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Common.Mapping;
using GhostMetrics.Core.Application.Common.Models;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSitesWithPagination;

public record GetGhostSitesWithPaginationQuery : IRequest<PaginatedList<BriefSiteDto>>
{
    public Guid ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetGhostSitesWithPaginationQueryHandler : IRequestHandler<GetGhostSitesWithPaginationQuery, PaginatedList<BriefSiteDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGhostSitesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BriefSiteDto>> Handle(GetGhostSitesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sites
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<BriefSiteDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}