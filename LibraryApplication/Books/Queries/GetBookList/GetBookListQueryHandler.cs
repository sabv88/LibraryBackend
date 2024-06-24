using AutoMapper;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookList
{
    public class GetBookListQueryHandler : IRequestHandler<GetBookListQuery, BookList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookListQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<BookList> Handle(GetBookListQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.bookRepository.GetAllAsync(cancellationToken);
            var books = _mapper.Map<List<BookLookupDto>>(entity);

            return new BookList { Books = books };
        }
    }
}