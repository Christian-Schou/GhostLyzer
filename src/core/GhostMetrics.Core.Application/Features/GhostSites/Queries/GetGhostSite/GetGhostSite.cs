using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.GhostSites.Queries.GetGhostSite;

public record GetGhostSiteQuery(Guid Id) : IRequest<GhostSiteDto>;

public class GetGhostSiteQueryHandler : IRequestHandler<GetGhostSiteQuery, GhostSiteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGhostSiteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GhostSiteDto> Handle(GetGhostSiteQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sites
            .AsNoTracking()
            .Include(x => x.IntegrationDetails)
            .ProjectTo<GhostSiteDto>(_mapper.ConfigurationProvider)
            .FirstAsync(x => x.Id == request.Id, cancellationToken);
    }
}