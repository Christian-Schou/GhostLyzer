using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Services.Ghost;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService : IGhostApiService
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<GhostApiService> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public GhostApiService(
        IApplicationDbContext context,
        ILogger<GhostApiService> logger,
        IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }
}