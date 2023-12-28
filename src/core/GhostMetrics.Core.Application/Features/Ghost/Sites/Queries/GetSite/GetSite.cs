using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSite;

public record GetGhostSiteQuery(Guid Id) : IRequest<SiteDto>;

public class GetGhostSiteQueryHandler : IRequestHandler<GetGhostSiteQuery, SiteDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetGhostSiteQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SiteDto> Handle(GetGhostSiteQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sites
            .AsNoTracking()
            .Include(x => x.IntegrationDetails)
            .ProjectTo<SiteDto>(_mapper.ConfigurationProvider)
            .FirstAsync(x => x.Id == request.Id, cancellationToken);
    }
}