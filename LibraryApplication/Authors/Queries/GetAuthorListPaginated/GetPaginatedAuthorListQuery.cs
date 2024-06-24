using LibraryApplication.DTOs.Authors.Responce;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public record GetPaginatedAuthorListQuery(int PageNumber, int PageSize) : IRequest<AuthorPaginatedList>;
}
