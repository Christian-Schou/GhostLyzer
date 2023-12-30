using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Core.Application.Services.GhostMetrics;

namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService : IGhostMetricsDataService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GhostMetricsDataService> _logger;
    private readonly IGhostApiService _ghostApi;
    private readonly IUnitOfWork _unitOfWork;

    public GhostMetricsDataService(
        IApplicationDbContext context,
        ILogger<GhostMetricsDataService> logger,
        IGhostApiService ghostApi,
        IUnitOfWork unitOfWork)
    {
        _context = context;
        _logger = logger;
        _ghostApi = ghostApi;
        _unitOfWork = unitOfWork;
    }
}