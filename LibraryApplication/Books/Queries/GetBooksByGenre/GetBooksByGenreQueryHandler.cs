using AutoMapper;
using LibraryApplication.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByGenre
{
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, BookByGenreList>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBooksByGenreQueryHandler(
            IMapper mapper, IBookRepository bookRepository) => (_mapper, _bookRepository) = (mapper, bookRepository);

        public async Task<BookByGenreList> Handle(GetBooksByGenreQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _bookRepository.GetBooksByGenreAsync(request.Genre);
            var books = _mapper.Map<List<BookByGenreDto>>(entities);
            return new BookByGenreList { Books = books };
        }
    }
}