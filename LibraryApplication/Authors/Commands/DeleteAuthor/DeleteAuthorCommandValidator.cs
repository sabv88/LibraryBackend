using FluentValidation;

namespace LibraryApplication.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(deleteAuthorCommand => deleteAuthorCommand.Id).NotEqual(Guid.Empty);
        }
    }
}