using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Unit> Handle(UpdateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.authorRepository.GetByIdAsync(request.updateAuthorDto.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.updateAuthorDto.Id);
            }

            entity = _mapper.Map<Author>(request.updateAuthorDto);
            var books = _mapper.Map<List<Book>>(request.updateAuthorDto.Books);
            //await _unitOfWork.authorRepository.AddBooksToAuthor(author, books, cancellationToken);
            _unitOfWork.authorRepository.Update(entity);
            await _unitOfWork.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
