using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.DTOs.OpenLibrary;
using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;

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

            // ISBNDB data model mappings
            CreateMap<BookEntries, BookDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.image))
                .ForMember(dest => dest.TitleLong, opt => opt.MapFrom(src => src.title_long))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.date_published))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.publisher))
                .ForMember(dest => dest.Synopsis, opt => opt.MapFrom(src => src.synopsis))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.subjects))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.authors))
                .ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.isbn13))
                .ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.isbn))
                .ForMember(dest => dest.Isbn10, opt => opt.MapFrom(src => src.isbn10))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language))
                .ForMember(dest => dest.Pages, opt => opt.MapFrom(src => src.pages))
                .ForMember(dest => dest.Edition, opt => opt.MapFrom(src => src.edition));

            CreateMap<ISBNDBBookDTO, BookCollectionDTO>()
                .ForMember(dest => dest.TotalBooks, opt => opt.MapFrom(src => src.total))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.books));
        }
    }
}
