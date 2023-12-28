using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.ValueObjects;

namespace GhostMetrics.Core.Application.Features.GhostSiteLists.Commands.UpdateGhostSiteList
{
	public record  UpdateGhostSiteListCommand : IRequest
	{
		public Guid Id { get; init; }
		public string? Title { get; init; }
		public Color? Color { get; init; }
	}

	internal class UpdateGhostSiteListCommandHandler : IRequestHandler<UpdateGhostSiteListCommand>
	{
		private readonly IApplicationDbContext _context;

		public UpdateGhostSiteListCommandHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Handle(UpdateGhostSiteListCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.SiteLists
				.FindAsync(new object[] { request.Id }, cancellationToken);

			Guard.Against.NotFound(request.Id, entity);

			entity.Title = request.Title;
			entity.Color = request.Color!;

			await _context.SaveChangesAsync(cancellationToken);
		}
	}
}
