using Microsoft.AspNetCore.Identity;

namespace GhostMetrics.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
