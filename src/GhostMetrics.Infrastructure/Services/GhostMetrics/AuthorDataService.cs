using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService
{
    public async Task ImportAndUpdateAuthorsForSiteAsync(Guid siteId, CancellationToken cancellationToken)
    {
        try
        {
            // Retrieve site details
            var site = await _context.Sites
                .AsNoTracking()
                .Include(x => x.IntegrationDetails)
                .FirstAsync(x => x.Id == siteId, cancellationToken);

            // Make sure we have the required integration details
            Guard.Against.NullOrEmpty(site.IntegrationDetails.ApiUrl);
            Guard.Against.NullOrEmpty(site.IntegrationDetails.ContentApiKey);
            
            // Get all authors from the Ghost Site
            var authors = _ghostApi
                .GetAllAuthors(site.IntegrationDetails.ApiUrl, site.IntegrationDetails.ContentApiKey);

            foreach (var author in authors)
            {
                await AddOrUpdateSingleGhostAuthorInDatabaseAsync(author, cancellationToken);
            }
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An unhandled error occured while trying to add or update all authors from Ghost site to GhostMetrics database");
            throw;
        }
    }

    public async Task AddOrUpdateSingleGhostAuthorInDatabaseAsync(
        GhostSharp.Entities.Author ghostAuthor, CancellationToken cancellationToken = default)
    {
        try
        {
            // Retrieve the existing author from the database
            var existingAuthor = _context.Authors.FirstOrDefault(a => a.GhostAuthorId == ghostAuthor.Id);

            if (existingAuthor != null)
            {
                // Update the existing author if it already exists
                existingAuthor.Name = ghostAuthor.Name;
                existingAuthor.Slug = ghostAuthor.Slug;
                existingAuthor.ProfileImage = ghostAuthor.ProfileImage;
                existingAuthor.Bio = ghostAuthor.Bio;
                existingAuthor.Url = ghostAuthor.Url;

                _context.Authors.Update(existingAuthor);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                // Create a new author if it doesn't exist
                var newAuthor = new Author
                {
                    GhostAuthorId = ghostAuthor.Id,
                    Name = ghostAuthor.Name,
                    Slug = ghostAuthor.Slug,
                    ProfileImage = ghostAuthor.ProfileImage,
                    Bio = ghostAuthor.Bio,
                    Url = ghostAuthor.Url
                };

                _context.Authors.Add(newAuthor);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "GhostMetrics: An unhandled error occured while trying to add or update Ghost author in GhostMetrics database");
            throw;
        }
    }
}