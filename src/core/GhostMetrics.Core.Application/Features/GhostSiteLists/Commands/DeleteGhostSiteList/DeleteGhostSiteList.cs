
using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.DeleteGhostSiteList
{
	public record DeleteGhostSiteListCommand(Guid Id) : IRequest;

	public class DeleteGhostSiteListCommandHandler : IRequestHandler<DeleteGhostSiteListCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeleteGhostSiteListCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Handle(DeleteGhostSiteListCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.SiteLists
				.Where(list => list.Id == request.Id)
				.SingleOrDefaultAsync(cancellationToken);

			Guard.Against.NotFound(request.Id, entity);

			_context.SiteLists.Remove(entity);

			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
