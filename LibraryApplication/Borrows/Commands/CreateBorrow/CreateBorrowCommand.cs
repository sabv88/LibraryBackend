using LibraryApplication.DTOs.Borrows.Request;
using MediatR;

namespace LibraryApplication.Borrows.Commands.CreateBorrow
{
    public record CreateBorrowCommand(Guid UserId, CreateBorrowDto createBorrowDto) : IRequest<Guid>;
}
