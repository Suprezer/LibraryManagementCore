using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.Books.GetAllBooks
{
    public class GetBooksQuery : IRequest<BookCollectionDTO>
    {
        public BookSearchCriteria? Criteria { get; set; }
    }
}
