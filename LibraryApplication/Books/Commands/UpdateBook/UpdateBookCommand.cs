using LibraryApplication.DTOs.Book.Request;
using MediatR;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(UpdateBookDto updateBookDto) : IRequest<Unit>;
}