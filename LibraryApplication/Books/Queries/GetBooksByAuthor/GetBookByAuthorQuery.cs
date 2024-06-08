using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public class GetBookByAuthorQuery : IRequest<BookByAuthorList>
    {
        public Guid authorId { get; set; }
    }
}
