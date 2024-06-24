using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Borrows.Commands.CreateBorrow
{
    public class CreateBorrowCommandHandler : IRequestHandler<CreateBorrowCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBorrowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Guid> Handle(CreateBorrowCommand request,
            CancellationToken cancellationToken)
        {
            var borrow = _mapper.Map<Borrow>(request.createBorrowDto);
            borrow.Id = Guid.NewGuid();
            borrow.TakingTime = DateTime.UtcNow;
            var entityBook = await _unitOfWork.bookRepository.GetByIdAsync(request.createBorrowDto.BookId);
            var entityUser = await _unitOfWork.userRepository.GetByIdAsyncWithBorrows(request.UserId);

            if(entityBook == null)
            {
                throw new NotFoundException(nameof(Book), request.createBorrowDto.BookId);
            }

            if (entityBook.Count < 1)
            {
                throw new OutOfStockException(nameof(Book), request.createBorrowDto.BookId);
            }

            if (entityUser == null)
            {
                entityUser = new User
                {
                    Id = request.UserId,
                    Books = new List<Book>(),
                    Borrows = new List<Borrow>()
                };

                await _unitOfWork.userRepository.AddAsync(entityUser, cancellationToken);
            }
            foreach(var borrowTemp in entityUser.Borrows)
            {
                if(borrowTemp.BookId == borrow.BookId && borrow.Returned == false) 
                {
                    throw new AlredyTakenException(request.createBorrowDto.BookId, request.UserId);
                }
            }
            entityUser.Borrows.Add(borrow);

            entityBook.Count--;

            await _unitOfWork.Save(cancellationToken);

            return borrow.Id;
        }

    }
}
