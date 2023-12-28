using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Core.Application.Services.GhostMetrics;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService : IGhostMetricsDataService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GhostMetricsDataService> _logger;
    private readonly IGhostApiService _ghostApi;

    public GhostMetricsDataService(
        IApplicationDbContext context,
        ILogger<GhostMetricsDataService> logger,
        IGhostApiService ghostApi)
    {
        _context = context;
        _logger = logger;
        _ghostApi = ghostApi;
    }
}