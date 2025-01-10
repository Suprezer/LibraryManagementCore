using LibraryManagement.Application.DTOs;
using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagementAPI.DTOs;
using MediatR;

namespace LibraryManagement.Application.Queries.ISBNDB.GetBooks
{
    public class GetISBNDBBooksQuery : IRequest<BookCollectionDTO>
    {
        public BookSearchCriteria searchCriteria { get; set; }
    }
}
