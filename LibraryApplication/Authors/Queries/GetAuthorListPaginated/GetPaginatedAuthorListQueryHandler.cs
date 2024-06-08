using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApplication.Common.Extentions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public class GetPaginatedAuthorListQueryHandler : IRequestHandler<GetPaginatedAuthorListQuery, AuthorPaginatedList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPaginatedAuthorListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<AuthorPaginatedList> Handle(GetPaginatedAuthorListQuery request,
            CancellationToken cancellationToken)
        {

            var a = await _unitOfWork.Repository<Author>().Entities
            .ProjectTo<AuthorPaginatedDto>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return new AuthorPaginatedList { Authors = a };
        }
    }
}