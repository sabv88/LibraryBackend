using FluentValidation;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator() 
        {
            RuleFor(updateBookCommand =>
                updateBookCommand.updateBookDto.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateBookCommand =>
                updateBookCommand.updateBookDto.Genre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateBookCommand =>
                updateBookCommand.updateBookDto.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(updateBookCommand =>
                updateBookCommand.updateBookDto.Count).GreaterThanOrEqualTo(0);
        }
    }
}
