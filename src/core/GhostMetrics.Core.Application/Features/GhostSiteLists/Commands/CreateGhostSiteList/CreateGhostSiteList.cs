using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.GhostSites;

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
        var entity = new GhostSiteList
        {
            Title = request.Title
        };

        _context.GhostSiteLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}