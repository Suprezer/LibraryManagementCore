using AutoMapper;
using LibraryManagement.Domain.Interfaces;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetAllBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            // Get all books
            var books = await _unitOfWork.Books.GetAllAsync();
            await _unitOfWork.CompleteAsync();

            // Automapper
            var bookDTOs = _mapper.Map<IEnumerable<BookDTO>>(books);
            return bookDTOs;    

        }
    }
}
