using FluentValidation;

namespace LibraryApplication.Books.Queries.GetBookById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator() 
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
        }
    }
}
