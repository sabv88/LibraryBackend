using FluentValidation;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(updateAuthorCommand => updateAuthorCommand.updateAuthorDto.Id).NotEqual(Guid.Empty);
            RuleFor(updateAuthorCommand =>
               updateAuthorCommand.updateAuthorDto.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.updateAuthorDto.Surname).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateAuthorCommand =>
                updateAuthorCommand.updateAuthorDto.DateOfBirth).NotNull().NotEqual(DateTime.MinValue);
        }
    }
}
