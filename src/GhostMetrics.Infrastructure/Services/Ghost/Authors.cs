using GhostSharp.Entities;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService
{
    public List<Author> GetAllAuthors(string baseUrl, string contentApiKey)
    {
        try
        {
            var ghost = new GhostSharp.GhostContentAPI(baseUrl, contentApiKey);
            var authors = ghost.GetAuthors();
            return authors.Authors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ghost API Service: An unhandled error occured while trying to get the authors from Ghost CMS API. Please check the logs for more details");
            throw;
        }
    }
}