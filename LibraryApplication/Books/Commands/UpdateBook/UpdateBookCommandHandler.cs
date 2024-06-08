using LibraryApplication.Common.Exceptions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork) =>
            _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(UpdateBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Book>().GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.ISBN = request.ISBN;
            entity.Title = request.Title;
            entity.Genre = request.Genre;
            entity.Description = request.Description;
            entity.Count = request.Count;
            entity.ImagePath = request.ImagePath;
            entity.Authors = request.Authors;

            foreach (var author in request.Authors)
            {
                var entityAuthor = await _unitOfWork.Repository<Author>().GetByIdAsync(author.Id);
                if (entityAuthor != null)
                {
                    entity.Authors.Add(entityAuthor);
                }
            }
            await _unitOfWork.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
