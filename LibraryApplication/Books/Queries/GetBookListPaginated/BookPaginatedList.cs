using MediatR;

namespace LibraryApplication.Books.Queries.GetBookListPaginated
{
    public class BookPaginatedList : IRequest<BookPaginatedList>
    {
        public IList<BookPaginatedDto>? Books { get; set; }
    }
}
