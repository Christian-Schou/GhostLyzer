using GhostMetrics.Core.Domain.Events;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Core.Application.Features.GhostSites.EventHandlers;

public class GhostSiteCreatedEventHandler : INotificationHandler<GhostSiteCreatedEvent>
{
    private readonly ILogger<GhostSiteCreatedEventHandler> _logger;

    public GhostSiteCreatedEventHandler(ILogger<GhostSiteCreatedEventHandler> logger)
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