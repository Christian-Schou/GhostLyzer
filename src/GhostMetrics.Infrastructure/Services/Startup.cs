using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Core.Application.Services.GhostMetrics;
using GhostMetrics.Infrastructure.Services.Ghost;
using GhostMetrics.Infrastructure.Services.GhostMetrics;
using Microsoft.Extensions.DependencyInjection;

namespace GhostMetrics.Infrastructure.Services;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IGhostApiService, GhostApiService>();
        services.AddTransient<IGhostMetricsDataService, GhostMetricsDataService>();
        
        return services;
    }
}