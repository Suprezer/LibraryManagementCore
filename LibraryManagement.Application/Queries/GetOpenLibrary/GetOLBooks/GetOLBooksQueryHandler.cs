using AutoMapper;
using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.IService;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.GetOpenLibrary.GetOLBooks
{
    public class GetOLBooksQueryHandler : IRequestHandler<GetOLBooksQuery, ICollection<BookDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IOpenLibraryBookService _openLibraryBookService;

        public GetOLBooksQueryHandler(IMapper mapper, IOpenLibraryBookService openLibraryBookService)
        {
            _mapper = mapper;
            _openLibraryBookService = openLibraryBookService;
        }

        public async Task<ICollection<BookDTO>> Handle(GetOLBooksQuery request, CancellationToken cancellationToken)
        {
            var SearchCriteria = request.SearchCriteria;
            // List of found books matching search criteria
            List<BookDTO> books = new List<BookDTO>();

            if (!string.IsNullOrEmpty(SearchCriteria.Title))
            {
                var response = await _openLibraryBookService.GetBooksByTitleAsync(SearchCriteria.Title);

                if (response != null & response.docs != null)
                {
                    foreach (var doc in response.docs)
                    {
                        var bookDTO = _mapper.Map<BookDTO>(doc);
                        books.Add(bookDTO);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(SearchCriteria.Author))
            {
                var book = await _openLibraryBookService.GetBooksByAuthorAsync(SearchCriteria.Author);

                if (book != null)
                {
                    books.Add(_mapper.Map<BookDTO>(book));
                }
            }

            return books;
        }
    }
}
