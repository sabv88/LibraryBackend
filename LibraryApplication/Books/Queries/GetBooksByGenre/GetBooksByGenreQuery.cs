using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByGenre
{
    public record GetBooksByGenreQuery(string Genre) : IRequest<BookByGenreList>;
}
