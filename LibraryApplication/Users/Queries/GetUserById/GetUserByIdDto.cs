using AutoMapper;
using LibraryApplication.Common.Mappings;
using LibraryDomain.Entities;

namespace LibraryApplication.Users.Queries.GetUserById
{
    public class GetUserByIdDto : IMapWith<User>
    {
        public List<Borrow>? Borrows { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetUserByIdDto>()
                .ForMember(UserDto => UserDto.Borrows,
                    opt => opt.MapFrom(user => user.Borrows));
        }
    }
}
