using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryApplication.Repositories;
using LibraryDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            var entity = await _unitOfWork.Repository<Author>().Entities.ProjectTo<AuthorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new AuthorList { Authors = entity };
        }
    }
}