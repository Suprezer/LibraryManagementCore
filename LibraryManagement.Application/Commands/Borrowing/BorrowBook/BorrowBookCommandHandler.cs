using LibraryManagement.Application.Commands.Borrowing.BorrowBook;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.BorrowBook
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrowBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.BookId);
            if (book == null || book.Quantity <= 0)
            {
                throw new Exception("Book not available for borrowing.");
            }

            var borrowing = new BorrowingEnt
            {
                BookId = request.BookId,
                UserId = request.UserId,
                BorrowDate = DateTime.UtcNow,
                ReturnDate = DateTime.UtcNow.AddDays(28)
            };

            book.Quantity -= 1;
            await _unitOfWork.Books.UpdateAsync(book);
            await _unitOfWork.Borrowings.AddAsync(borrowing);
            await _unitOfWork.CompleteAsync();

            return borrowing.Id;
        }
    }
}
