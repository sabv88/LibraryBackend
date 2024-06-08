using FluentValidation;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand => updateAuthorCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateAuthorCommand =>
               updateAuthorCommand.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.Surname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.DateOfBirth).NotNull().NotEqual(DateTime.MinValue);
        }
    }
}
