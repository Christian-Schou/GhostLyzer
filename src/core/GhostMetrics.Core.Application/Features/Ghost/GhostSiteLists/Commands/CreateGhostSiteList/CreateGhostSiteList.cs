using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.CreateGhostSiteList;

public record CreateGhostSiteListCommand : IRequest<Guid>
{
    public string? Title { get; set; }
}

public class CreateGhostSiteListCommandHandler : IRequestHandler<CreateGhostSiteListCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateGhostSiteListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateGhostSiteListCommand request, CancellationToken cancellationToken)
    {
        var entity = new SiteList
        {
            Title = request.Title
        };

        _context.SiteLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}