using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Common.Mapping;
using GhostMetrics.Core.Application.Common.Models;

namespace GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSitesWithPagination;

public record GetGhostSitesWithPaginationQuery : IRequest<PaginatedList<GhsotSiteBriefDto>>
{
    public Guid ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetGhostSitesWithPaginationQueryHandler : IRequestHandler<GetGhostSitesWithPaginationQuery, PaginatedList<GhsotSiteBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGhostSitesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GhsotSiteBriefDto>> Handle(GetGhostSitesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.GhostSites
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<GhsotSiteBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}