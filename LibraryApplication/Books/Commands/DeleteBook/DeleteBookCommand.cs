using MediatR;

namespace LibraryApplication.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(Guid Id) : IRequest<Unit>;
}