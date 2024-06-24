using LibraryApplication.DTOs.Book.Request;
using MediatR;

namespace LibraryApplication.Books.Commands.CreateBook
{
    public record CreateBookCommand(CreateBookDto createBookDto) : IRequest<Guid>;
}
