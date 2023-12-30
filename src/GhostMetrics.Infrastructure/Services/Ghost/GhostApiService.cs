using GhostMetrics.Core.Application.Services.Ghost;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService : IGhostApiService
{
    private readonly ILogger<GhostApiService> _logger;

    public GhostApiService(ILogger<GhostApiService> logger)
    {
        _logger = logger;
    }
}