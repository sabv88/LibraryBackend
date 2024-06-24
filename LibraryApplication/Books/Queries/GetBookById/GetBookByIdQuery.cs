using LibraryApplication.DTOs.Book.Responce;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(Guid Id) : IRequest<GetBookByIdDto>;
}