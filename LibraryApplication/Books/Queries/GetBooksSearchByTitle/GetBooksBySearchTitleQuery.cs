using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksSearchByName
{
    public record GetBooksBySearchTitleQuery(string Title) : IRequest<BookBySearchTitleList>;
}
