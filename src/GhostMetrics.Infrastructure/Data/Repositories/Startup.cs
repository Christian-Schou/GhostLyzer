using GhostMetrics.Core.Application.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public static class Startup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ISiteRepository, SiteRepository>();

        return services;
    }
}