using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQuery : IRequest<BookByGenreList>
    {
        public string Genre { get; set; }
    }
}
