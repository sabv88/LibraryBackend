using MediatR;

namespace LibraryApplication.Books.Queries.GetBookListPaginated
{
    public class GetPaginatedBookListQuery : IRequest<BookPaginatedList>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
