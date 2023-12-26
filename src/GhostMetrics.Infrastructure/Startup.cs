using GhostMetrics.Infrastructure.Data;
using GhostMetrics.Infrastructure.Identity;
using GhostMetrics.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GhostMetrics.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabaseServices(configuration);
        services.AddIdentityServices();
        services.AddHttpClient();
        services.AddInfrastructureServices();
        return services;
    }
}