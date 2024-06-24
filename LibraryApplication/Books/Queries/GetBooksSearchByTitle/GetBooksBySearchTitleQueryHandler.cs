using AutoMapper;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksSearchByName
{
    public class GetBooksBySearchTitleQueryHandler : IRequestHandler<GetBooksBySearchTitleQuery, BookBySearchTitleList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksBySearchTitleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<BookBySearchTitleList> Handle(GetBooksBySearchTitleQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.bookRepository.GetBooksBySearchTitleAsync(request.Title, cancellationToken);
            var books = _mapper.Map<List<BookBySearchTitleDto>>(entities);
            return new BookBySearchTitleList { Books = books };
        }
    }
}
