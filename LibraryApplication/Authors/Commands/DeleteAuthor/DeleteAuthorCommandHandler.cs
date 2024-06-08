using LibraryApplication.Common.Exceptions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Author>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            await _unitOfWork.Repository<Author>().DeleteAsync(entity);
            await _unitOfWork.Save(cancellationToken);

            return Unit.Value;
        }
    }
}