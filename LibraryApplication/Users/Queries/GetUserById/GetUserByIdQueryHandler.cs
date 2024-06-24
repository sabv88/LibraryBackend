using AutoMapper;
using LibraryApplication.Common.Exceptions;
using LibraryApplication.DTOs.Users.Request;
using LibraryDomain.Entities;
using LibraryDomain.Interfaces.Repositories;
using MediatR;

namespace LibraryApplication.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository,
            IMapper mapper) => (_userRepository, _mapper) = (userRepository, mapper);

        public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsyncWithBorrows(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<GetUserByIdDto>(entity);
        }
    }
}
