using LibraryApplication.DTOs.Authors.Responce;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorList
{
    public record GetAuthorListQuery : IRequest<AuthorList>;
}
