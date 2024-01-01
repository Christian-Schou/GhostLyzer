using GhostMetrics.Core.Application.Common.Interfaces;

namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Commands.CreateGhostSite;

public class CreateSiteCommandValidator : AbstractValidator<CreateGhostSiteCommand>
{
    private readonly IApplicationDbContext _context;
    
    public CreateSiteCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(x => x.Title)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(x => x.ApiUrl)
            .NotNull()
            .NotEmpty()
                .WithMessage("Please provide the URL for the API of the Ghost Site.")
                .WithMessage("The API URL is provided when creating a new custom Ghost Integration.")
            .Must(BeAValidUrl!)
                .WithMessage("The API URL is not valid. Please check the URL and try again.")
            .MustAsync(BeAUniqueApiUrl!)
                .WithMessage("This API URL is already in use for another Ghost Site.");

        RuleFor(x => x.AdminApiKey)
            .NotEmpty()
                .WithMessage("Please provide the Admin API Key.");
        
        RuleFor(x => x.ContentApiKey)
            .NotEmpty()
                .WithMessage("Please provide the Content API Key.");
    }

    public async Task<bool> BeAUniqueApiUrl(string apiUrl, CancellationToken cancellationToken)
    {
        return await _context.Sites
            .AllAsync(x => x.IntegrationDetails!.ApiUrl != apiUrl, cancellationToken);
    }
    
    public bool BeAValidUrl(string uri)
    {
        return Uri.TryCreate(uri, UriKind.Absolute, out _);
    }
}