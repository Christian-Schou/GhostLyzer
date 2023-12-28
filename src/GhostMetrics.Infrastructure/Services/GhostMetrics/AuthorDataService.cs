using GhostMetrics.Core.Domain.Entities.Ghost;
using Microsoft.EntityFrameworkCore;

namespace GhostMetrics.Infrastructure.Services.GhostMetrics;

public partial class GhostMetricsDataService
{
    public async Task ImportAndUpdateAuthorsForSiteAsync(Guid siteId, CancellationToken cancellationToken)
    {
        // Retrieve site details
        var site = await _context.Sites
            .AsNoTracking()
            .Include(x => x.IntegrationDetails)
            .FirstAsync(x => x.Id == siteId, cancellationToken);

        // Make sure we got a usable response from the database
        if (string.IsNullOrEmpty(site.IntegrationDetails.ApiUrl) || string.IsNullOrEmpty(site.IntegrationDetails.ContentApiKey))
        {
            return;
        }

        // Get all authors from the Ghost Site
        var authors = _ghostApi
            .GetAllAuthors(site.IntegrationDetails.ApiUrl, site.IntegrationDetails.ContentApiKey);

        foreach (var author in authors)
        {
            // Retrieve the existing author from the database
            var existingAuthor = _context.Authors.FirstOrDefault(a => a.GhostAuthorId == author.Id);

            if (existingAuthor != null)
            {
                // Update the existing author if it already exists
                existingAuthor.Name = author.Name;
                existingAuthor.Slug = author.Slug;
                existingAuthor.ProfileImage = author.ProfileImage;
                existingAuthor.Bio = author.Bio;
                existingAuthor.Url = author.Url;

                _context.Authors.Update(existingAuthor);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                // 3. Create a new author if it doesn't exist
                var newAuthor = new Author
                {
                    GhostAuthorId = author.Id,
                    Name = author.Name,
                    Slug = author.Slug,
                    ProfileImage = author.ProfileImage,
                    Bio = author.Bio,
                    Url = author.Url
                };

                _context.Authors.Add(newAuthor);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}