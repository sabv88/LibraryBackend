using MediatR;

namespace LibraryApplication.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<BookList>
    {
    }
}
