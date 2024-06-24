using MediatR;

namespace LibraryApplication.DTOs.Authors.Responce
{
    public class AuthorPaginatedList : IRequest<AuthorPaginatedList>
    {
        public IList<AuthorPaginatedDto> Authors { get; set; }
    }
}
