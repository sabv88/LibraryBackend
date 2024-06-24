using AutoMapper;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, BookByAuthorList>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByAuthorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<BookByAuthorList> Handle(GetBookByAuthorQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.bookRepository.GetAllAuthorsBooksAsync(request.authorId, cancellationToken);
            var books = _mapper.Map<List<BookByAuthorDto>>(entities);
            return new BookByAuthorList { Books = books };
        }
    }
}
