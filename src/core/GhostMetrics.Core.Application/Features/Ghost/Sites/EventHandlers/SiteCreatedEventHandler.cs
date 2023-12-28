using GhostMetrics.Core.Domain.Events;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.EventHandlers;

public class SiteCreatedEventHandler : INotificationHandler<GhostSiteCreatedEvent>
{
    private readonly ILogger<SiteCreatedEventHandler> _logger;

    public SiteCreatedEventHandler(ILogger<SiteCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(GhostSiteCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GhostMetrics Domain Event: {DomainEvent}", notification.GetType().Name);
        // TODO: Add some awesome stuff here!
        return Task.CompletedTask;
    }
}