using LibraryManagementAPI.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.GetOpenLibraryBooks.GetOLBooks
{
    public class GetOLBooksQuery : IRequest<ICollection<BookDTO>>
    {
        public BookSearchCriteria SearchCriteria { get; set; }
    }
}
