using System.Text.Json;
using GhostMetrics.Core.Domain.Models.GhostCms.Content;
using Microsoft.Extensions.Logging;

namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService
{
    public async Task<List<GhostApiPost>> GetAllGhostPostsAsync(string baseUrl, string contentApiKey)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var postsApiPath = $"/ghost/api/content/posts/?key={contentApiKey}";
            var apiUrl = GenerateGhostApiUrl(baseUrl, postsApiPath);
            var allPosts = new List<GhostApiPost>();
            var currentPage = 1;

            do
            {
                var response = await client.GetAsync($"{apiUrl}&page={currentPage}");

                response.EnsureSuccessStatusCode();

                await using var responseStream = await response.Content.ReadAsStreamAsync();
                var apiResponse = await JsonSerializer.DeserializeAsync<GhostPostsApiResponse>(responseStream);

                if (apiResponse?.ApiPosts != null)
                {
                    allPosts.AddRange(apiResponse.ApiPosts);
                }

                currentPage = apiResponse?.Meta?.Pagination?.NextPage ?? 0;

            } while (currentPage != 0);

            return allPosts;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ghost API Service: An unhandled error occured. Please check the logs for more details");
            throw;
        }
    }
}