using AutoMapper;
using LibraryManagement.Application.Commands.CreateBook;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagementAPI.DTOs;
using Moq;
using Xunit;

namespace LibraryManagement.Tests.Unit_Tests.Application
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateBookCommandHandler _handler;

        public CreateBookCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateBookCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBookId_WhenBookIsCreated()
        {
            // Arrange
            var command = new CreateBookCommand { Body = new BookDTO { Title = "Test Book" } };
            var book = new Book { Id = Guid.NewGuid(), Title = "Test Book" };

            _mapperMock.Setup(m => m.Map<Book>(command.Body)).Returns(book);
            _unitOfWorkMock.Setup(u => u.Books.AddAsync(book)).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.FromResult(1));

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(book.Id, result);
        }

        [Fact]
        public async Task Handle_ShouldCallCompleteAsync_WhenBookIsCreated()
        {
            // Arrange
            var command = new CreateBookCommand { Body = new BookDTO { Title = "Test Book" } };
            var book = new Book { Id = Guid.NewGuid(), Title = "Test Book" };

            _mapperMock.Setup(m => m.Map<Book>(command.Body)).Returns(book);
            _unitOfWorkMock.Setup(u => u.Books.AddAsync(book)).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.FromResult(1));

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenAddAsyncFails()
        {
            // Arrange
            var command = new CreateBookCommand { Body = new BookDTO { Title = "Test Book" } };
            var book = new Book { Id = Guid.NewGuid(), Title = "Test Book" };

            _mapperMock.Setup(m => m.Map<Book>(command.Body)).Returns(book);
            _unitOfWorkMock.Setup(u => u.Books.AddAsync(book)).ThrowsAsync(new Exception("AddAsync failed"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
