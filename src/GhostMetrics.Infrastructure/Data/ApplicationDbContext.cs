using System.Reflection;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<SiteList> SiteLists => Set<SiteList>();
    public DbSet<Site> Sites => Set<Site>();
    public DbSet<IntegrationDetail> SiteIntegrationDetails => Set<IntegrationDetail>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostAuthor> PostAuthors => Set<PostAuthor>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}