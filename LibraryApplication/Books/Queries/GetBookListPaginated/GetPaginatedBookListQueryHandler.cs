using MediatR;
using AutoMapper;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;

namespace LibraryApplication.Books.Queries.GetBookListPaginated
{
    public class GetPaginatedBookListQueryHandler : IRequestHandler<GetPaginatedBookListQuery, BookPaginatedList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaginatedBookListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<BookPaginatedList> Handle(GetPaginatedBookListQuery request,
            CancellationToken cancellationToken)
        {

            var a = await _unitOfWork.bookRepository.GetPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            var books = _mapper.Map<List<BookPaginatedDto>>(a);

            return new BookPaginatedList { Books = books };
        }
    }
}

