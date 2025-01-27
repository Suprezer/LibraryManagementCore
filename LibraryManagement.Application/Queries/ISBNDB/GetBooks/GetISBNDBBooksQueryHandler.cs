using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.ISBNDB.GetBooks
{
    /// <summary>
    /// Handles the query to get books from the ISBNDB service.
    /// </summary>
    public class GetISBNDBBooksQueryHandler : IRequestHandler<GetISBNDBBooksQuery, BookCollectionDTO>
    {
        private readonly IMapper _mapper;
        private readonly IISBNDBBookService _iSBNDBBookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetISBNDBBooksQueryHandler"/> class.
        /// </summary>
        /// <param name="mapper">The mapper to map between domain and DTO objects.</param>
        /// <param name="iSBNDBBookService">The service to interact with the ISBNDB API.</param>
        public GetISBNDBBooksQueryHandler(IMapper mapper, IISBNDBBookService iSBNDBBookService)
        {
            _mapper = mapper;
            _iSBNDBBookService = iSBNDBBookService;
        }

        // Handles the query to get books based on the search criteria.
        public async Task<BookCollectionDTO> Handle(GetISBNDBBooksQuery request, CancellationToken cancellationToken)
        {
            // Fetch books from the ISBNDB service based on the search criteria
            var isbnDbBooks = await _iSBNDBBookService.GetBooksAsync(request.searchCriteria);

            // Map the fetched books to the BookCollectionDTO
            var bookCollectionDTO = _mapper.Map<BookCollectionDTO>(isbnDbBooks);

            // Return the mapped book collection DTO
            return bookCollectionDTO;
        }
    }
}
