using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<GetAuthorByIdDto> Handle(GetAuthorByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.authorRepository
                .GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }

            return _mapper.Map<GetAuthorByIdDto>(entity);
        }
    }
}
