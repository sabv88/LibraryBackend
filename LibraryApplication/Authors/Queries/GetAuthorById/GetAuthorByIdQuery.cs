using LibraryApplication.DTOs.Authors.Responce;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorById
{
    public record GetAuthorByIdQuery(Guid Id) : IRequest<GetAuthorByIdDto>;
}