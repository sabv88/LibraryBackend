using AutoMapper;
using LibraryApplication.DTOs.Borrows.Request;
using LibraryDomain.Entities;

namespace LibraryApplication.DTOs.Borrows
{
    public class BorrowMappingProfile : Profile
    {
        public BorrowMappingProfile() 
        {
            CreateMap<Borrow, CreateBorrowDto>().ReverseMap(); 
        }
    }
}
