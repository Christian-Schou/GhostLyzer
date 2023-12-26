using System.Text.Json.Serialization;

namespace GhostMetrics.Core.Domain.Models.GhostCms.Content;

public class GhostPostsApiResponse
{
    [JsonPropertyName("posts")]
    public List<GhostApiPost>? ApiPosts { get; set; }
    
    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }
}

public class GhostApiPost
{
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }
    
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("feature_image")]
    public string? FeatureImage { get; set; }
    
    [JsonPropertyName("featured")]
    public bool Featured { get; set; }
    
    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    [JsonPropertyName("published_at")]
    public DateTime PublishedAt { get; set; }
    
    [JsonPropertyName("custom_excerpt")]
    public string? CustomExcerpt { get; set; }
    
    [JsonPropertyName("canonical_url")]
    public string? CanonicalUrl { get; set; }
    
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    
    [JsonPropertyName("excerpt")]
    public string? Excerpt { get; set; }
    
    [JsonPropertyName("reading_time")]
    public int ReadingTime { get; set; }
    
    [JsonPropertyName("access")]
    public bool Access { get; set; }
    
    [JsonPropertyName("og_title")]
    public string? OgTitle { get; set; }
    
    [JsonPropertyName("og_description")]
    public string? OgDescription { get; set; }
    
    [JsonPropertyName("twitter_title")]
    public string? TwitterTitle { get; set; }
    
    [JsonPropertyName("twitter_description")]
    public string? TwitterDescription { get; set; }
    
    [JsonPropertyName("meta_title")]
    public string? MetaTitle { get; set; }
    
    [JsonPropertyName("meta_description")]
    public string? MetaDescription { get; set; }
}