using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            await _unitOfWork.Books.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();

            return request.Id;
        }
    }
}
