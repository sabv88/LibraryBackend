﻿using AutoMapper;
using LibraryApplication.Common.Mappings;
using LibraryDomain.Entities;

namespace LibraryApplication.Authors.Queries.GetAuthorListPaginated
{
    public class AuthorPaginatedDto : IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Country { get; set; }
        public List<Book>? Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorPaginatedDto>()
                .ForMember(authorDto => authorDto.Id,
                    opt => opt.MapFrom(author => author.Id))
                .ForMember(authorDto => authorDto.Name,
                    opt => opt.MapFrom(author => author.Name))
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
