using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;
using System.Net;

namespace LibraryApplication.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommandHandler : IRequestHandler<CreateBorrowCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBorrowCommandHandler(IUnitOfWork unitOfWork) =>
                  _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateBorrowCommand request,
            CancellationToken cancellationToken)
        {

            var borrow = new Borrow
            {
                Id = Guid.NewGuid(),
                BookId = request.BookId,
                TakingTime = request.TakingTime,
                ReturnTime = request.ReturnTime,
            };
            var entityBook = await _unitOfWork.Repository<Book>().GetByIdAsync(request.BookId);
            var entityUser = await _unitOfWork.Repository<User>().GetByIdAsync(request.UserId);

            if (entityUser == null)
            {
                entityUser = new User
                {
                    Id = request.UserId,
                    Books = new List<Book>(),
                    Borrows = new List<Borrow>()
                };

                await _unitOfWork.Repository<User>().AddAsync(entityUser);
                entityUser.Borrows.Add(borrow);
            }
            else
            {
                entityUser.Borrows.Add(borrow);
            }

            entityBook.Count--;

            await _unitOfWork.Save(cancellationToken);

            return borrow.Id;
        }

    }
}
