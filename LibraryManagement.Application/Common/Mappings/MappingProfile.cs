using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;
using LibraryManagement.Application.DTOs.OpenLibrary;

namespace LibraryManagement.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            // Author mappings
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

            // Genre mappings
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();

            // Publisher mappings
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<PublisherDTO, Publisher>();

            CreateMap<Edition, EditionDTO>();
            CreateMap<EditionDTO, Edition>();

            // OpenLibrary mappings
            //CreateMap<OLBookResponseDTO, BookDTO>()
            //    .ForMember
        }
    }
}
