using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookListPaginated
{
    public record GetPaginatedBookListQuery(int PageNumber, int PageSize) : IRequest<BookPaginatedList>;
}
