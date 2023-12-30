namespace GhostMetrics.Core.Domain.Entities.Analytics;

public class BaseAnalytics : BaseEntity<Guid>
{
    /// <summary>
    /// Pages hits
    /// </summary>
    public int PageViewsFromSiteCreation { get; set; }
    
    /// <summary>
    /// Number of unique visitors
    /// </summary>
    public int UniquesFromSiteCreation { get; set; }
    
    /// <summary>
    /// Number of returning visitors
    /// </summary>
    public int ReturningVisitorsFromSiteCreation { get; set; }
    
    /// <summary>
    /// Time spent on the website
    /// </summary>
    public int TotalTimeFromCreation { get; set; }
    
    public List<AnalyticsEntry>? Data { get; set; }
}

public class AnalyticsEntry : BaseEntity<Guid>
{
    /// <summary>
    /// Date for when the data was added from Umami
    /// </summary>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// Pages hits
    /// </summary>
    public int PageViews { get; set; }
    
    /// <summary>
    /// Number of unique visitors
    /// </summary>
    public int Uniques { get; set; }
    
    /// <summary>
    /// Number of returning visitors
    /// </summary>
    public int ReturningVisitors { get; set; }
    
    /// <summary>
    /// Time spent on the website
    /// </summary>
    public int TotalTime { get; set; }
    
    public Guid BaseAnalyticsId { get; set; }
    public BaseAnalytics? BaseAnalytics { get; set; }
}