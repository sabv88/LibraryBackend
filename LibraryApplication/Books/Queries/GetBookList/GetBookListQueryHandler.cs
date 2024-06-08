using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var entity = await _unitOfWork.Repository<Book>().Entities.ProjectTo<BookLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new BookList { Books = entity };
        }
    }
}