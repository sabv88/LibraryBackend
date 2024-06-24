using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Book.Responce;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Books.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, GetBookByISBNDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByISBNQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper) => (_mapper, _unitOfWork) = (mapper, unitOfWork);

        public async Task<GetBookByISBNDto> Handle(GetBookByISBNQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.bookRepository.GetByISBNAsync(request.ISBN, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.ISBN);
            }

            return _mapper.Map<GetBookByISBNDto>(entity);
        }
    }
}
