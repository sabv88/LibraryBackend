using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Guid> Handle(CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.createBookDto);
            if(await _unitOfWork.bookRepository.GetForCheckAsync(book, cancellationToken) != null)
            {
                throw new AlredyExistException(nameof(Book), book);
            }

            book.Id = Guid.NewGuid();
            await _unitOfWork.bookRepository.AddAsync(book, cancellationToken);
            var authors = _mapper.Map<List<Author>>(request.createBookDto.Authors);
            await _unitOfWork.bookRepository.AddAuthorsToBook(book, authors, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return book.Id;
        }
    }
}