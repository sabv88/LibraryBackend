using FluentValidation;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(createAuthorCommand =>
                createAuthorCommand.сreateAuthorDto.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createAuthorCommand =>
                createAuthorCommand.сreateAuthorDto.Surname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createAuthorCommand =>
                createAuthorCommand.сreateAuthorDto.DateOfBirth).NotNull().NotEqual(DateTime.MinValue);
        }
    }
}
