using GhostMetrics.Core.Application.Common.Data;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Infrastructure.Data.Interceptors;
using GhostMetrics.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GhostMetrics.Infrastructure.Data;

public static class Startup
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(connectionString,
            message: "Connection string 'DefaultConnection' was not found in the configuration.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        return services;
    }
}