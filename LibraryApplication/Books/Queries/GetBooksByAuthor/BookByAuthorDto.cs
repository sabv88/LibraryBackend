using AutoMapper;
using LibraryApplication.Common.Mappings;
using LibraryDomain.Entities;

namespace LibraryApplication.Books.Queries.GetBooksByAuthor
{
    public class BookByAuthorDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string? ISBN { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? ImagePath { get; set; }
        public List<Author>? Authors { get; set; }
        public List<User>? Users { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookByAuthorDto>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.ISBN,
                    opt => opt.MapFrom(book => book.ISBN))
                .ForMember(bookDto => bookDto.Genre,
                    opt => opt.MapFrom(book => book.Genre))
                .ForMember(bookDto => bookDto.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.Count,
                    opt => opt.MapFrom(book => book.Count))
                .ForMember(bookDto => bookDto.ImagePath,
                    opt => opt.MapFrom(book => book.ImagePath))
               .ForMember(bookDto => bookDto.Authors,
                    opt => opt.MapFrom(book => book.Authors))
                .ForMember(bookDto => bookDto.Users,
                    opt => opt.MapFrom(book => book.Users));
        }
    }
}