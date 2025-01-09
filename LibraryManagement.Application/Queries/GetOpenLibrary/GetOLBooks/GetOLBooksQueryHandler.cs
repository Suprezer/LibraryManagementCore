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
            var searchCriteria = request.SearchCriteria;
            // List of found books matching search criteria
            List<BookDTO> books = new List<BookDTO>();

            if (!string.IsNullOrEmpty(searchCriteria.Title))
            {
                var response = await _openLibraryBookService.GetBooksByTitleAsync(searchCriteria.Title);

                if (response != null && response.docs != null)
                {
                    foreach (var doc in response.docs)
                    {
                        var bookDTO = _mapper.Map<BookDTO>(doc);
                        bookDTO.OLId = RemoveKeyPrefix(bookDTO.OLId);
                        if (bookDTO.Authors != null)
                        {
                            foreach (var author in bookDTO.Authors)
                            {
                                author.AuthorKey = RemoveKeyPrefix(author.AuthorKey);
                            }
                        }
                        books.Add(bookDTO);
                    }
                }
            }
            else if (!string.IsNullOrEmpty(searchCriteria.Author))
            {
                var response = await _openLibraryBookService.GetBooksByAuthorAsync(searchCriteria.Author);

                if (response != null && response.docs != null)
                {
                    foreach (var doc in response.docs)
                    {
                        var bookDTO = _mapper.Map<BookDTO>(doc);
                        bookDTO.OLId = RemoveKeyPrefix(bookDTO.OLId);
                        if (bookDTO.Authors != null)
                        {
                            foreach (var author in bookDTO.Authors)
                            {
                                author.AuthorKey = RemoveKeyPrefix(author.AuthorKey);
                            }
                        }
                        books.Add(bookDTO);
                    }
                }
            }

            return books;
        }

        private string RemoveKeyPrefix(string key)
        {
            return key?.Split('/').Last();
        }
    }
}
