using LibraryApplication.Common.Exceptions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Author>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.DateOfBirth = request.DateOfBirth;
            entity.Country = request.Country;

            foreach (var book in request.Books)
            {
                var entityBook = await _unitOfWork.Repository<Book>().GetByIdAsync(book.Id);
                if (entityBook != null)
                {
                    entity.Books.Add(entityBook);
                }
            }

            await _unitOfWork.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
