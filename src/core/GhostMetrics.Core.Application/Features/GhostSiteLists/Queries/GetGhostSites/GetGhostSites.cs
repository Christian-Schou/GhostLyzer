using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Queries.GetGhostSites;

public record GetGhostSitesQuery : IRequest<GhostSitesVm>;

public class GetGhostSitesQueryHandler : IRequestHandler<GetGhostSitesQuery, GhostSitesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGhostSitesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GhostSitesVm> Handle(GetGhostSitesQuery request, CancellationToken cancellationToken)
    {
        return new GhostSitesVm
        {
            Lists = await _context.GhostSiteLists
                .AsNoTracking()
                .ProjectTo<GhostSiteListDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}