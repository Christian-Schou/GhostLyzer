using GhostMetrics.Core.Application.Common.Interfaces;
using GhostMetrics.Core.Application.Data.Repositories;
using GhostMetrics.Core.Domain.Entities.Ghost;

namespace GhostMetrics.Infrastructure.Data.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    private readonly ILogger<AuthorRepository> _logger;
    
    public AuthorRepository(IApplicationDbContext context, ILogger<AuthorRepository> logger) : base(context)
    {
        _logger = logger;
    }

    public async Task<Guid> AddOrUpdateAuthorAsync(GhostSharp.Entities.Author ghostAuthor, CancellationToken cancellationToken)
    {
        try
        {
            // Retrieve the existing author from the database
            var existingAuthor = Context.Authors.FirstOrDefault(a => a.GhostAuthorId == ghostAuthor.Id);

            if (existingAuthor != null)
            {
                // Update the existing author if it already exists
                existingAuthor.Name = ghostAuthor.Name;
                existingAuthor.Slug = ghostAuthor.Slug;
                existingAuthor.ProfileImage = ghostAuthor.ProfileImage;
                existingAuthor.Bio = ghostAuthor.Bio;
                existingAuthor.Url = ghostAuthor.Url;

                Context.Authors.Update(existingAuthor);
                await Context.SaveChangesAsync(cancellationToken);
                return existingAuthor.Id;
            }

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

            await Context.Authors.AddAsync(newAuthor, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
            return newAuthor.Id;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "GhostMetrics: An unhandled error occured while trying to add or update Ghost author in GhostMetrics database");
            throw;
        }
    }
}