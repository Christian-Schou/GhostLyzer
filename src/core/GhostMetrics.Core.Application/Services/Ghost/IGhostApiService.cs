using GhostSharp.Entities;

namespace GhostMetrics.Core.Application.Services.Ghost;

public interface IGhostApiService
{
    public List<Post> GetAllPosts(string apiUrl, string contentApiKey);

    #region Authors

    public List<Author> GetAllAuthors(string baseUrl, string contentApiKey);

    #endregion Authors

}