using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Core.Application.Services.GhostMetrics;

namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService : IGhostMetricsDataService
{
    private readonly ILogger<GhostMetricsDataService> _logger;
    private readonly IGhostApiService _ghostApi;
    private readonly IUnitOfWork _unitOfWork;

    public GhostMetricsDataService(ILogger<GhostMetricsDataService> logger,
        IGhostApiService ghostApi,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _ghostApi = ghostApi;
        _unitOfWork = unitOfWork;
    }
}