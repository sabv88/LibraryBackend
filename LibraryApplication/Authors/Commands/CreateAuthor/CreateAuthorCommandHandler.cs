using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<Guid> Handle(CreateAuthorCommand request,
            CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request.сreateAuthorDto);

            if(await _unitOfWork.authorRepository.GetForCheckAsync(author, cancellationToken) != null)
            {
                throw new AlredyExistException(nameof(Author), author);
            }

            author.Id = Guid.NewGuid();
            await _unitOfWork.authorRepository.AddAsync(author, cancellationToken);
            var books = _mapper.Map<List<Book>>(request.сreateAuthorDto.Books);
            await _unitOfWork.authorRepository.AddBooksToAuthor(author, books, cancellationToken);
            await _unitOfWork.Save(cancellationToken);

            return author.Id;
        }
    }
}