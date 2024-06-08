using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public class AuthorPaginatedList : IRequest<AuthorPaginatedList>
    {
        public IList<AuthorPaginatedDto> Authors { get; set; }
    }
}
