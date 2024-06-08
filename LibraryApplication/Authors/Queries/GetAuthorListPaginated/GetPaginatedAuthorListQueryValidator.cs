using FluentValidation;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public class GetPaginatedAuthorListQueryValidator : AbstractValidator<GetPaginatedAuthorListQuery>
    {
        public GetPaginatedAuthorListQueryValidator() 
        {
            RuleFor(x => x.PageNumber)
                    .GreaterThanOrEqualTo(1)
                    .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
