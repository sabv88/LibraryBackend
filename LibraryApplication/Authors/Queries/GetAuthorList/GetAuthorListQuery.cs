using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQuery : IRequest<AuthorList>
    {
    }
}
