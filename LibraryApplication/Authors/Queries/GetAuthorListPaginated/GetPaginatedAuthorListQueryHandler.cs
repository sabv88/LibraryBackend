using AutoMapper;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Interfaces.Repositories;
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

            var entity = await _unitOfWork.authorRepository
            .GetPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            var authors = _mapper.Map<List<AuthorPaginatedDto>>(entity);

            return new AuthorPaginatedList { Authors = authors };
        }
    }
}