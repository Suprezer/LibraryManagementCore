using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.ISBNDB.GetBooks
{
    public class GetISBNDBBooksQueryHandler : IRequestHandler<GetISBNDBBooksQuery, BookCollectionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IISBNDBBookService _iSBNDBBookService;

        public GetISBNDBBooksQueryHandler(IMapper mapper, IISBNDBBookService iSBNDBBookService)
        {
            _mapper = mapper;
            _iSBNDBBookService = iSBNDBBookService;
        }

        public async Task<BookCollectionDTO> Handle(GetISBNDBBooksQuery request, CancellationToken cancellationToken)
        {
            var isbnDbBooks = await _iSBNDBBookService.GetBooksAsync(request.searchCriteria);

            var bookCollectionDTO = _mapper.Map<BookCollectionDTO>(isbnDbBooks);

            return bookCollectionDTO;
        }
    }
}
