namespace GhostMetrics.Core.Application.Features.Ghost.Sites.Queries.GetSitesWithPagination;

public class GetSitesWithPaginationValidator : AbstractValidator<GetGhostSitesWithPaginationQuery>
{
    public GetSitesWithPaginationValidator()
    {
        RuleFor(x => x.ListId)
            .NotEmpty().WithMessage("List ID is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("Page number must be at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("Page size must be a least greater than or equal to 1.");
    }
}