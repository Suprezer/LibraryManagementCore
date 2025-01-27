using LibraryManagement.Application.Commands.DeleteBook;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using Moq;
using Xunit;

namespace LibraryManagement.Tests.Unit_Tests.Application
{
    public class DeleteBookCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteBookCommandHandler _handler;

        public DeleteBookCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteBookCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenDeleteAsyncFails()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var book = new Book { Id = bookId, Title = "Test Book" };

            _unitOfWorkMock.Setup(u => u.Books.GetByIdAsync(bookId)).ReturnsAsync(book);
            _unitOfWorkMock.Setup(u => u.Books.DeleteAsync(bookId)).ThrowsAsync(new Exception("DeleteAsync failed"));

            var command = new DeleteBookCommand { Id = bookId };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
