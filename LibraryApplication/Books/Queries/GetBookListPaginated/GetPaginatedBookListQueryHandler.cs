using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using LibraryApplication.Common.Extentions;

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

            var a = await _unitOfWork.Repository<Book>().Entities
            .ProjectTo<BookPaginatedDto>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new BookPaginatedList { Books = a };
        }
    }
}

