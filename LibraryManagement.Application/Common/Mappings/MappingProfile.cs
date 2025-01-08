using AutoMapper;
using LibraryManagement.Application.DTOs;
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

            // OpenLibrary mappings
            CreateMap<OLBookContentDTO, BookDTO>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.author_name.Zip(src.author_key, (name, key) => new AuthorDTO { AuthorName = name, AuthorKey = key }).ToList()))
                .ForMember(dest => dest.Languages, opt => opt.MapFrom(src => src.language ?? new List<string>()))
                .ForMember(dest => dest.CoverEditionKey, opt => opt.MapFrom(src => src.cover_edition_key))
                .ForMember(dest => dest.EditionKeys, opt => opt.MapFrom(src => src.edition_key ?? new List<string>()))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.isbn ?? new List<string>()))
                .ForMember(dest => dest.MedianPageCount, opt => opt.MapFrom(src => src.number_of_pages_median))
                .ForMember(dest => dest.EditionCount, opt => opt.MapFrom(src => src.edition_count))
                .ForMember(dest => dest.FirstPublishedYear, opt => opt.MapFrom(src => src.first_publish_year > 0 ? new DateTime?(new DateTime(src.first_publish_year, 1, 1)) : null))
                .ForMember(dest => dest.TotalRatingCount, opt => opt.MapFrom(src => src.ratings_count))
                .ForMember(dest => dest.RatingCount1, opt => opt.MapFrom(src => src.ratings_count_1))
                .ForMember(dest => dest.RatingCount2, opt => opt.MapFrom(src => src.ratings_count_2))
                .ForMember(dest => dest.RatingCount3, opt => opt.MapFrom(src => src.ratings_count_3))
                .ForMember(dest => dest.RatingCount4, opt => opt.MapFrom(src => src.ratings_count_4))
                .ForMember(dest => dest.RatingCount5, opt => opt.MapFrom(src => src.ratings_count_5))
                .ForMember(dest => dest.RatingsAverage, opt => opt.MapFrom(src => src.ratings_average))
                .ForMember(dest => dest.OLId, opt => opt.MapFrom(src => src.key));

            CreateMap<Entry, EditionDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AuthorKey, opt => opt.MapFrom(src => src.authors.FirstOrDefault().key))
                .ForMember(dest => dest.OLId, opt => opt.MapFrom(src => src.key))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.languages.FirstOrDefault().key))
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.number_of_pages))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.ISBN10, opt => opt.MapFrom(src => src.isbn_10.FirstOrDefault()))
                .ForMember(dest => dest.ISBN13, opt => opt.MapFrom(src => src.isbn_13.FirstOrDefault()))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.publishers.FirstOrDefault()))
                .ForMember(dest => dest.Desciption, opt => opt.MapFrom(src => src.description != null ? src.description.ToString() : null))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.publish_date));
        }
    }
}
