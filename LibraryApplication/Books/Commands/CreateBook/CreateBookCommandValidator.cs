using FluentValidation;

namespace LibraryApplication.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand =>
                createBookCommand.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createBookCommand =>
                createBookCommand.Genre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createBookCommand =>
                createBookCommand.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(createBookCommand =>
                createBookCommand.Count).GreaterThanOrEqualTo(0);
        }
    }
}
