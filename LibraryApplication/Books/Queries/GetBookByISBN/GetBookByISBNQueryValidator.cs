using FluentValidation;

namespace LibraryApplication.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
    {
        public GetBookByISBNQueryValidator() 
        {
            RuleFor(query => query.ISBN).NotNull().NotEmpty();
        }
    }
}
