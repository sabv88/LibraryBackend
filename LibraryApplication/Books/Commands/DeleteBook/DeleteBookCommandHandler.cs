using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.bookRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            _unitOfWork.bookRepository.Delete(entity);
            await _unitOfWork.Save(cancellationToken);

            return Unit.Value;
        }
    }
}