using AutoMapper;
using LibraryApplication.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksSearchByName
{
    public class GetBooksBySearchTitleQueryHandler : IRequestHandler<GetBooksBySearchTitleQuery, BookBySearchTitleList>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBooksBySearchTitleQueryHandler(
            IMapper mapper, IBookRepository bookRepository) => (_mapper, _bookRepository) = (mapper, bookRepository);

        public async Task<BookBySearchTitleList> Handle(GetBooksBySearchTitleQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _bookRepository.GetBooksBySearchTitleAsync(request.Title);
            var books = _mapper.Map<List<BookBySearchTitleDto>>(entities);
            return new BookBySearchTitleList { Books = books };
        }
    }
}
