using FluentValidation;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateBookCommand =>
                updateBookCommand.Genre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateBookCommand =>
                updateBookCommand.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(updateBookCommand =>
                updateBookCommand.Count).GreaterThanOrEqualTo(0);
        }
    }
}
