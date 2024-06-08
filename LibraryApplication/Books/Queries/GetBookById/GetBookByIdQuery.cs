using MediatR;

namespace LibraryApplication.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<GetBookByIdDto>
    {
        public Guid Id { get; set; }
    }
}