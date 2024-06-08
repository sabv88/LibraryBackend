using AutoMapper;
using LibraryApplication.Books.Queries.GetBookById;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, GetBookByISBNDto>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public GetBookByISBNQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper, IBookRepository bookRepository) => (_mapper, _bookRepository) = (mapper, bookRepository);

        public async Task<GetBookByISBNDto> Handle(GetBookByISBNQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _bookRepository.GetByISBNAsync(request.ISBN);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.ISBN);
            }

            return _mapper.Map<GetBookByISBNDto>(entity);
        }
    }
}
