using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagementAPI.DTOs;
using Xunit;

namespace LibraryManagement.Tests.Unit_Tests.Application
{
    public class AutoMapperProfileTests
    {
        private readonly IMapper _mapper;

        public AutoMapperProfileTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookDTO, Book>().ReverseMap();
                cfg.CreateMap<AuthorDTO, Author>().ReverseMap();
                cfg.CreateMap<PublisherDTO, Publisher>().ReverseMap();
                // Add other mappings here
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void ShouldMapBookDTOToBook()
        {
            // Arrange
            var bookDto = new BookDTO { Title = "Test Book" };

            // Act
            var book = _mapper.Map<Book>(bookDto);

            // Assert
            Assert.Equal(bookDto.Title, book.Title);
        }

        [Fact]
        public void ShouldMapBookToBookDTO()
        {
            // Arrange
            var book = new Book { Title = "Test Book" };

            // Act
            var bookDto = _mapper.Map<BookDTO>(book);

            // Assert
            Assert.Equal(book.Title, bookDto.Title);
        }

        [Fact]
        public void ShouldMapAuthorDTOToAuthor()
        {
            // Arrange
            var authorDto = new AuthorDTO { AuthorName = "Test Author" };

            // Act
            var author = _mapper.Map<Author>(authorDto);

            // Assert
            Assert.Equal(authorDto.AuthorName, author.AuthorName);
        }

        [Fact]
        public void ShouldMapAuthorToAuthorDTO()
        {
            // Arrange
            var author = new Author { AuthorName = "Test Author" };

            // Act
            var authorDto = _mapper.Map<AuthorDTO>(author);

            // Assert
            Assert.Equal(author.AuthorName, authorDto.AuthorName);
        }

        [Fact]
        public void ShouldMapPublisherDTOToPublisher()
        {
            // Arrange
            var publisherDto = new PublisherDTO { Name = "Test Publisher" };

            // Act
            var publisher = _mapper.Map<Publisher>(publisherDto);

            // Assert
            Assert.Equal(publisherDto.Name, publisher.Name);
        }

        [Fact]
        public void ShouldMapPublisherToPublisherDTO()
        {
            // Arrange
            var publisher = new Publisher { Name = "Test Publisher" };

            // Act
            var publisherDto = _mapper.Map<PublisherDTO>(publisher);

            // Assert
            Assert.Equal(publisher.Name, publisherDto.Name);
        }
    }
}
