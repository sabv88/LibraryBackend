using AutoMapper;
using LibraryApplication.Common.Mappings;

namespace LibraryWebApi.Models.Author
{
    public class BookForCreateOrUpdateAuthorDto : IMapWith<LibraryDomain.Entities.Book>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<BookForCreateOrUpdateAuthorDto, LibraryDomain.Entities.Book>()
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id));
        }
    }
}
