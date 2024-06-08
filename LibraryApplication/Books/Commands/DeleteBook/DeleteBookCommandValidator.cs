using FluentValidation;

namespace LibraryApplication.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(deleteAuthorCommand => deleteAuthorCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
