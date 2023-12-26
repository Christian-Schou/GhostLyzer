using GhostMetrics.Core.Application.Services.Ghost;
using GhostMetrics.Infrastructure.Services.Ghost;
using Microsoft.Extensions.DependencyInjection;

namespace GhostMetrics.Infrastructure.Services;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IGhostApiService, GhostApiService>();

        return services;
    }
}