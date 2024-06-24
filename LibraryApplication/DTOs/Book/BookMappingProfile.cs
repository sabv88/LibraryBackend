using AutoMapper;
using LibraryApplication.DTOs.Book.Request;
using LibraryApplication.DTOs.Book.Responce;

namespace LibraryApplication.DTOs.Book
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() 
        {
            CreateMap<AuthorForCreateOrUpdatBookDto, LibraryDomain.Entities.Author>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, CreateBookDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, UpdateBookDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, BookByAuthorDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, BookByGenreDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, BookBySearchTitleDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, BookLookupDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, BookPaginatedDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, GetBookByIdDto>().ReverseMap();
            CreateMap<LibraryDomain.Entities.Book, GetBookByISBNDto>().ReverseMap();

        }
    }
}
