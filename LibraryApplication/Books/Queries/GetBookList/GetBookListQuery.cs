using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookList
{
    public record GetBookListQuery : IRequest<BookList>;
}
