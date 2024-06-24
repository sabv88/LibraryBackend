using FluentValidation;

namespace LibraryApplication.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(createBookCommand =>
                createBookCommand.createBookDto.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createBookCommand =>
                createBookCommand.createBookDto.Genre).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createBookCommand =>
                createBookCommand.createBookDto.Description).NotNull().NotEmpty().MaximumLength(500);
            RuleFor(createBookCommand =>
                createBookCommand.createBookDto.Count).GreaterThanOrEqualTo(0);
        }
    }
}
