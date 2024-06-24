using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Unit> Handle(UpdateBookCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.bookRepository.GetByIdAsync(request.updateBookDto.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.updateBookDto.Id);
            }

            entity = _mapper.Map<Book>(request.updateBookDto);
            var authors = _mapper.Map<List<Author>>(request.updateBookDto.Authors);
            await _unitOfWork.bookRepository.AddAuthorsToBook(entity, authors, cancellationToken);
            _unitOfWork.bookRepository.Update(entity);
            await _unitOfWork.Save(cancellationToken);
            return Unit.Value;
        }
    }
}
