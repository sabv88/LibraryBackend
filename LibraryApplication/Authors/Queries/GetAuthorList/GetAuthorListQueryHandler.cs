using AutoMapper;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler : IRequestHandler<GetAuthorListQuery, AuthorList>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<AuthorList> Handle(GetAuthorListQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.authorRepository.GetAllAsync(cancellationToken);
            var authors = _mapper.Map<List<AuthorLookupDto>>(entity);
            return new AuthorList { Authors = authors };
        }
    }
}