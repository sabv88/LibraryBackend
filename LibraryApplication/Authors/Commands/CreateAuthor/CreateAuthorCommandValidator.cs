using FluentValidation;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(createAuthorCommand =>
                createAuthorCommand.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createAuthorCommand =>
                createAuthorCommand.Surname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createAuthorCommand =>
                createAuthorCommand.DateOfBirth).NotNull().NotEqual(DateTime.MinValue);
        }
    }
}
