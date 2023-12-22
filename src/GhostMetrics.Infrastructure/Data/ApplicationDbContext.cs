using System.Reflection;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.GhostSites;
using GhostMetrics.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<GhostSiteList> GhostSiteLists => Set<GhostSiteList>();
    public DbSet<GhostSite> GhostSites => Set<GhostSite>();
    public DbSet<GhostSiteIntegrationDetail> GhostSiteIntegrationDetails => Set<GhostSiteIntegrationDetail>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}