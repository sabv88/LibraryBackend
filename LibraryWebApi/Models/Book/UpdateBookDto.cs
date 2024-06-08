using AutoMapper;
using LibraryApplication.Books.Commands.UpdateBook;
using LibraryApplication.Common.Mappings;
using LibraryDomain.Entities;
using LibraryWebApi.Models.Author;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Models.Book
{
    public class UpdateBookDto : IMapWith<UpdateBookCommand>
    {
        public Guid Id { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
        public string? ImagePath { get; set; }
        public List<AuthorForCreateOrUpdatBookDto>? Authors { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>()
                .ForMember(bookCommand => bookCommand.Id,opt=>opt.MapFrom(bookDto => bookDto.Id))
                .ForMember(bookCommand => bookCommand.Title,
                    opt => opt.MapFrom(bookDto => bookDto.Title))
                .ForMember(bookCommand => bookCommand.ISBN,
                    opt => opt.MapFrom(bookDto => bookDto.ISBN))
                .ForMember(bookCommand => bookCommand.Genre,
                    opt => opt.MapFrom(bookDto => bookDto.Genre))
                .ForMember(bookCommand => bookCommand.Description,
                    opt => opt.MapFrom(bookDto => bookDto.Description))
                .ForMember(bookCommand => bookCommand.Count,
                    opt => opt.MapFrom(bookDto => bookDto.Count))
                .ForMember(bookCommand => bookCommand.ImagePath,
                    opt => opt.MapFrom(bookDto => bookDto.ImagePath))
                .ForMember(bookCommand => bookCommand.Authors,
                    opt => opt.MapFrom(bookDto => bookDto.Authors));
        }

    }
}
