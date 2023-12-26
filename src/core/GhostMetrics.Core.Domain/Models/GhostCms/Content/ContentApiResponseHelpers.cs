using System.Text.Json.Serialization;

namespace GhostMetrics.Core.Domain.Models.GhostCms.Content;

public class Meta
{
    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; }
}

public class Pagination
{
    [JsonPropertyName("page")]
    public int? PageNumber {get; set; }
    
    [JsonPropertyName("limit")]
    public int? PageSize {get; set; }
    
    [JsonPropertyName("pages")]
    public int?Pages {get; set; }
    
    [JsonPropertyName("total")]
    public int? TotalItems {get; set; }
    
    [JsonPropertyName("next")]
    public int? NextPage {get; set; }
    
    [JsonPropertyName("prev")]
    public int? PreviousPage {get; set; }
}