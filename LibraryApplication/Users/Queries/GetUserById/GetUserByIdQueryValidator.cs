
using FluentValidation;

namespace LibraryApplication.Users.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEqual(Guid.Empty);
        }
    }
}
