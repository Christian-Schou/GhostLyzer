using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Core.Domain.Events;

namespace GhostMetrics.Core.Application.Features.GhostSites.Commands.CreateGhostSite;

public record CreateGhostSiteCommand : IRequest<Guid>
{
    public Guid ListId { get; init; }
    public string? Title { get; init; }
    public string? Note { get; init; }
    public string? ApiUrl { get; init; }
    public string? ContentApiKey { get; init; }
    public string? AdminApiKey { get; init; }

}

public class CreateGhostSiteCommandHandler : IRequestHandler<CreateGhostSiteCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateGhostSiteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateGhostSiteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Site
        {
            ListId = request.ListId,
            Title = request.Title,
            Note = request.Note ?? "N/A",
            Paused = false,
            Indexed = false,
            IntegrationDetails = new IntegrationDetail
            {
                ApiUrl = request.ApiUrl,
                ContentApiKey = request.ContentApiKey,
                AdminApiKey = request.AdminApiKey
            }
        };
        
        entity.AddDomainEvent(new GhostSiteCreatedEvent(entity));

        _context.Sites.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}