using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksSearchByName
{
    public class GetBooksBySearchTitleQuery : IRequest<BookBySearchTitleList>
    {
        public string Title { get; set; }
    }
}
