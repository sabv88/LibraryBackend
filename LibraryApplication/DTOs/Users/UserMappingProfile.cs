using AutoMapper;
using LibraryApplication.DTOs.Users.Request;
using LibraryDomain.Entities;

namespace LibraryApplication.DTOs.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, GetUserByIdDto>().ReverseMap();
        }
    }
}
