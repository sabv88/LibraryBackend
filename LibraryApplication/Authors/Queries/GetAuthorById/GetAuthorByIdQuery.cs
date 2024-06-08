using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<GetAuthorByIdDto>
    {
        public Guid Id { get; set; }
    }
}