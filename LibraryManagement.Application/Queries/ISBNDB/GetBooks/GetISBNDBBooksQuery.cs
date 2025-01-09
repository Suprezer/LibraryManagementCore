using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.DTOs.ISBNDB;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.ISBNDB.GetBooks
{
    public class GetISBNDBBooksQuery : IRequest<ISBNDBBookDTO>
    {
        public BookSearchCriteria searchCriteria { get; set; }
    }
}
