using AutoMapper;
using LibraryApplication.Common.Mappings;

namespace LibraryWebApi.Models.Book
{
    public class AuthorForCreateOrUpdatBookDto : IMapWith<LibraryDomain.Entities.Author>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthorForCreateOrUpdatBookDto, LibraryDomain.Entities.Author>()
                .ForMember(authorDto => authorDto.Id,
                    opt => opt.MapFrom(author => author.Id));
        }
    }
}
