using FluentValidation;

namespace LibraryApplication.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
        }
    }
}