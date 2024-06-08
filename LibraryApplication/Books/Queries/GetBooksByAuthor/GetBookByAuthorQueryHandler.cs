using AutoMapper;
using LibraryApplication.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, BookByAuthorList>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBookByAuthorQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper, IBookRepository bookRepository) => (_mapper, _bookRepository) = (mapper, bookRepository);

        public async Task<BookByAuthorList> Handle(GetBookByAuthorQuery request,
            CancellationToken cancellationToken)
        {
            var entities = await _bookRepository.GetAllAuthorsBooksAsync(request.authorId);
            var books = _mapper.Map<List<BookByAuthorDto>>(entities);
            return new BookByAuthorList { Books = books };
        }
    }
}
