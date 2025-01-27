using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LibraryManagement.Tests.Integration_Tests.Infrastructure
{
    public class BookRepositoryIntegrationTests
    {
        private readonly DbContextOptions<LibraryContext> _dbContextOptions;

        public BookRepositoryIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryTestDb")
                .Options;
        }

        private Book CreateTestBook()
        {
            return new Book
            {
                Id = Guid.NewGuid(),
                Title = "Test Book",
                CoverImage = "test_cover.jpg",
                TitleLong = "Test Book Long Title",
                PublishedDate = "2023-01-01",
                Publisher = new Publisher { Id = Guid.NewGuid(), Name = "Test Publisher" },
                PublisherId = Guid.NewGuid(),
                Synopsis = "Test Synopsis",
                Authors = new List<Author> { new Author { Id = Guid.NewGuid(), AuthorName = "Test Author" } },
                Isbn13 = "1234567890123",
                Isbn = "1234567890",
                Isbn10 = "1234567890",
                Language = "en",
                Pages = 100,
                Edition = "1st",
                Quantity = 10
            };
        }

        [Fact]
        public async Task AddAsync_ShouldAddBook()
        {
            // Arrange
            using var context = new LibraryContext(_dbContextOptions);
            var repository = new BookRepository(context);
            var book = CreateTestBook();

            // Act
            await repository.AddAsync(book);
            await context.SaveChangesAsync();

            // Assert
            var addedBook = await context.Books.FindAsync(book.Id);
            Assert.NotNull(addedBook);
            Assert.Equal("Test Book", addedBook.Title);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            using var context = new LibraryContext(_dbContextOptions);
            var repository = new BookRepository(context);
            var book = CreateTestBook();
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            // Act
            var retrievedBook = await repository.GetByIdAsync(book.Id.Value);

            // Assert
            Assert.NotNull(retrievedBook);
            Assert.Equal("Test Book", retrievedBook.Title);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Arrange
            using var context = new LibraryContext(_dbContextOptions);
            var repository = new BookRepository(context);
            var nonExistentBookId = Guid.NewGuid();

            // Act
            var retrievedBook = await repository.GetByIdAsync(nonExistentBookId);

            // Assert
            Assert.Null(retrievedBook);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateBook()
        {
            // Arrange
            using var context = new LibraryContext(_dbContextOptions);
            var repository = new BookRepository(context);
            var book = CreateTestBook();
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            // Act
            book.Title = "Updated Test Book";
            await repository.UpdateAsync(book);
            await context.SaveChangesAsync();

            // Assert
            var updatedBook = await context.Books.FindAsync(book.Id);
            Assert.NotNull(updatedBook);
            Assert.Equal("Updated Test Book", updatedBook.Title);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveBook_WhenBookExists()
        {
            // Arrange
            using var context = new LibraryContext(_dbContextOptions);
            var repository = new BookRepository(context);
            var book = CreateTestBook();
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            // Act
            await repository.DeleteAsync(book.Id.Value);
            await context.SaveChangesAsync();

            // Assert
            var deletedBook = await context.Books.FindAsync(book.Id);
            Assert.Null(deletedBook);
        }
    }
}
