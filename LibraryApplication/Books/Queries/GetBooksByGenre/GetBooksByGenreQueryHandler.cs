using AutoMapper;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, BookByGenreList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksByGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<BookByGenreList> Handle(GetBooksByGenreQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.bookRepository.GetBooksByGenreAsync(request.Genre, cancellationToken);
            var books = _mapper.Map<List<BookByGenreDto>>(entities);
            return new BookByGenreList { Books = books };
        }
    }
}