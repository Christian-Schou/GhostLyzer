namespace GhostMetrics.Infrastructure.Services.Ghost;

public partial class GhostApiService
{
    public string GenerateGhostApiUrl(string baseUrl, string apiPath)
    {
        // Ensure that baseUrl ends with a single slash
        if (!baseUrl.EndsWith("/"))
        {
            baseUrl += "/";
        }

        // Ensure that apiPath does not start with a slash
        if (apiPath.StartsWith("/"))
        {
            apiPath = apiPath.Substring(1);
        }

        // Combine baseUrl and apiPath to form the complete URL
        string apiUrl = $"{baseUrl}{apiPath}";

        return apiUrl;
    }
}