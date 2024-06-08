using FluentValidation;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public class GetBookByAuthorQueryValidator : AbstractValidator<GetBookByAuthorQuery>
    {
        public GetBookByAuthorQueryValidator()
        {
            RuleFor(query => query.authorId).NotEqual(Guid.Empty);
        }
    }
}