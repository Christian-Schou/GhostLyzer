using GhostMetrics.Core.Application.Services.GhostMetrics;
using GhostMetrics.Core.Domain.Events;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.EventHandlers;

public class SiteCreatedEventHandler : INotificationHandler<GhostSiteCreatedEvent>
{
    private readonly ILogger<SiteCreatedEventHandler> _logger;
    private readonly IGhostMetricsDataService _ghostMetrics;

    public SiteCreatedEventHandler(ILogger<SiteCreatedEventHandler> logger, IGhostMetricsDataService ghostMetrics)
    {
        _logger = logger;
        _ghostMetrics = ghostMetrics;
    }
    
    public async Task Handle(GhostSiteCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GhostMetrics Domain Event: {DomainEvent}", notification.GetType().Name);

        // Import Ghost objects from Ghost Site API
        await _ghostMetrics.ImportAndUpdateAuthorsForSiteAsync(notification.Site.Id, cancellationToken);
        await _ghostMetrics.ImportAndUpdatePostsForSiteAsync(notification.Site.Id, cancellationToken);
    }
}