using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Domain.Filters;
using LibraryManagement.Domain.Interfaces;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.Books.GetAllBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, BookCollectionDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookCollectionDTO> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            BookSearching searchCriteria = _mapper.Map<BookSearching>(request.Criteria);

            // Get all books
            var bookCollection = await _unitOfWork.Books.GetAllAsync(searchCriteria);
            await _unitOfWork.CompleteAsync();

            // Automapper
            var bookCollectionDTO = _mapper.Map<BookCollectionDTO>(bookCollection);
            return bookCollectionDTO;
        }
    }
}
