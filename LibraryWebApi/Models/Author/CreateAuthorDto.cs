using AutoMapper;
using LibraryApplication.Authors.Commands.CreateAuthor;
using LibraryApplication.Common.Mappings;
using LibraryWebApi.Models.Book;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Models.Author
{
    public class CreateAuthorDto: IMapWith<CreateAuthorCommand>
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<BookForCreateOrUpdateAuthorDto>? Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                .ForMember(authorCommand => authorCommand.Name,
                    opt => opt.MapFrom(authorDto => authorDto.Name))
                .ForMember(authorCommand => authorCommand.Surname,
                    opt => opt.MapFrom(authorDto => authorDto.Surname))
                .ForMember(authorCommand => authorCommand.DateOfBirth,
                    opt => opt.MapFrom(authorDto => authorDto.DateOfBirth))
                .ForMember(authorCommand => authorCommand.Country,
                    opt => opt.MapFrom(authorDto => authorDto.Country))
                .ForMember(authorDto => authorDto.Books,
                    opt => opt.MapFrom(author => author.Books));
        }
    }
}
