using AutoMapper;
using LibraryApplication.Authors.Commands.UpdateAuthor;
using LibraryApplication.Common.Mappings;
using LibraryWebApi.Models.Book;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Models.Author
{
    public class UpdateAuthorDto : IMapWith<UpdateAuthorCommand>
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<BookForCreateOrUpdateAuthorDto>? Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorDto, UpdateAuthorCommand>()
                .ForMember(authorDto => authorDto.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorDto => authorDto.Name,
                    opt => opt.MapFrom(author => author.Surname))
                .ForMember(authorDto => authorDto.Surname,
                    opt => opt.MapFrom(author => author.Surname))
                .ForMember(authorDto => authorDto.DateOfBirth,
                    opt => opt.MapFrom(author => author.DateOfBirth))
                .ForMember(authorDto => authorDto.Country,
                    opt => opt.MapFrom(author => author.Country))
                .ForMember(authorDto => authorDto.Books,
                    opt => opt.MapFrom(author => author.Books));
        }
    }
}
