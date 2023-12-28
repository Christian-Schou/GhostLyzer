using GhostMetrics.Core.Domain.Constants;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Data;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initializer.InitializeAsync();

        await initializer.SeedAsync();
    }
}

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitializer(
        ILogger<ApplicationDbContextInitializer> logger, 
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occured while trying to initialize the database");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled error occured while trying to seed the database");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Seed default administrator role
        var adminRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(role => role.Name != adminRole.Name))
        {
            await _roleManager.CreateAsync(adminRole);
        }
        
        // Seed a default administrator for the application
        var adminUser = new ApplicationUser
        {
            UserName = "admin@ghostmetrics",
            Email = "admin@ghostmetrics",
            FirstName = "Ghost",
            LastName = "Metrics"
        };

        if (_userManager.Users.All(user => user.UserName != adminUser.UserName))
        {
            await _userManager.CreateAsync(adminUser, "GhostMetrics1!");
            if (!string.IsNullOrWhiteSpace(adminRole.Name))
            {
                await _userManager.AddToRolesAsync(adminUser, new[] { adminRole.Name });
            }
        }
        
        // Default data
        if (!_context.SiteLists.Any())
        {
            _context.SiteLists.Add(new SiteList
            {
                Title = "Default Site List",
                GhostSites =
                {
                    new Site
                    {
                        Title = "Default Ghost Site",
                        Indexed = false,
                        Paused = true,
                        IntegrationDetails = new IntegrationDetail
                        {
                            ApiUrl = "https://your-ghost-site.ghostmetrics",
                            AdminApiKey = "your-admin-api-key-here",
                            ContentApiKey = "your-content-api-key-here"
                        }
                    }
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}