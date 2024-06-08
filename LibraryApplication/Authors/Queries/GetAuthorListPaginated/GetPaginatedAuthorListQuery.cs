using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public class GetPaginatedAuthorListQuery : IRequest<AuthorPaginatedList>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
