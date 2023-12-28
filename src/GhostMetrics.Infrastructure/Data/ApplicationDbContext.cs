using System.Reflection;
using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Domain.Entities.Analytics;
using GhostMetrics.Core.Domain.Entities.Ghost;
using GhostMetrics.Core.Domain.Entities.SEO;
using GhostMetrics.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    #region Site

    public DbSet<SiteList> SiteLists => Set<SiteList>();
    public DbSet<Site> Sites => Set<Site>();
    public DbSet<IntegrationDetail> SiteIntegrationDetails => Set<IntegrationDetail>();

    #endregion

    #region Posts & Authors

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<PostAuthor> PostAuthors => Set<PostAuthor>();

    #endregion

    #region Analytics

    public DbSet<AuthorAnalytics> AuthorAnalytics => Set<AuthorAnalytics>();
    public DbSet<PostAnalytics> PostAnalytics => Set<PostAnalytics>();
    public DbSet<TagAnalytics> TagAnalytics => Set<TagAnalytics>();
    public DbSet<BaseAnalytics> BaseAnalytics => Set<BaseAnalytics>();

    #endregion

    #region Seo

    public DbSet<PostSeo> PostSeo => Set<PostSeo>();
    public DbSet<TagSeo> TagSeo => Set<TagSeo>();

    #endregion
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}