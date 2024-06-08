using MediatR;

namespace LibraryApplication.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQuery : IRequest<GetBookByISBNDto>
    {
        public string ISBN { get; set; }
    }
}