using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Body.Title,
                Author = request.Body.Author,
                Genre = request.Body.Genre,
                PublishedDate = request.Body.PublishedDate,
            };

            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CompleteAsync();

            return book.Id;
        }
    }
}
