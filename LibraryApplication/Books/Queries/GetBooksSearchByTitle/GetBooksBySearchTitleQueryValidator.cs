using FluentValidation;

namespace LibraryApplication.Books.Queries.GetBooksSearchByName
{
    public class GetBooksBySearchTitleQueryValidator : AbstractValidator<GetBooksBySearchTitleQuery>
    {
        public GetBooksBySearchTitleQueryValidator()
        {
            RuleFor(query => query.Title).NotNull().NotEmpty();
        }
    }
}
