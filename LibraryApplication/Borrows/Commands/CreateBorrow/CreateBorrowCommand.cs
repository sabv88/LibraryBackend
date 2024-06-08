using MediatR;

namespace LibraryApplication.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime TakingTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
