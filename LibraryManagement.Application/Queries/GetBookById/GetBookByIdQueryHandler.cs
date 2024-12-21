using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Domain.Interfaces;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            // Get a book by id
            var book = await _unitOfWork.Books.GetByIdAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            if (book == null)
            {
                throw new NullReferenceException(request.Id.ToString());
            }

            // automapper
            var bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }
    }
}
