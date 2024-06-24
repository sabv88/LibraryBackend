
using FluentValidation;

namespace LibraryApplication.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQueryValidator : AbstractValidator<GetBooksByGenreQuery>
    {
        public GetBooksByGenreQueryValidator() 
        {
            RuleFor(query => query.Genre).NotNull().NotEmpty();
        }
    }
}
