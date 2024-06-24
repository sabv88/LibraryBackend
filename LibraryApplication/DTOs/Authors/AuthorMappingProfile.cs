using AutoMapper;
using LibraryApplication.DTOs.Authors.Request;
using LibraryApplication.DTOs.Authors.Responce;
using LibraryDomain.Entities;

namespace LibraryApplication.DTOs.Authors
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile() 
        {
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();
            CreateMap<Author, AuthorLookupDto>().ReverseMap();
            CreateMap<Author, AuthorPaginatedDto>().ReverseMap();
            CreateMap<Author, GetAuthorByIdDto>().ReverseMap();
            CreateMap<BookForCreateOrUpdateAuthorDto, LibraryDomain.Entities.Book>().ReverseMap();
        }
    }
}
