using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public record GetBookByAuthorQuery(Guid authorId) : IRequest<BookByAuthorList>;
}
