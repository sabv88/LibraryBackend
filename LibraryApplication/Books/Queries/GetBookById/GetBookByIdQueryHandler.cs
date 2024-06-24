using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

        public async Task<GetBookByIdDto> Handle(GetBookByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.bookRepository
                .GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<GetBookByIdDto>(entity);
        }
    }
}
