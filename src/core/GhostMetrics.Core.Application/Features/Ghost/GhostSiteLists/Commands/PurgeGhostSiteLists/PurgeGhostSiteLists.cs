
using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.PurgeGhostSiteLists;

public record PurgeGhostSiteListsCommand : IRequest;

public class PurgeGhostSiteListsCommandHandler : IRequestHandler<PurgeGhostSiteListsCommand>
{
	private readonly IApplicationDbContext _context;

	public PurgeGhostSiteListsCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task Handle(PurgeGhostSiteListsCommand request, CancellationToken cancellationToken)
	{
		_context.SiteLists.RemoveRange(_context.SiteLists);

		await _context.SaveChangesAsync(cancellationToken);
	}
}
