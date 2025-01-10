using LibraryManagement.Application.DTOs.Filters.ISBNDB;
using LibraryManagement.Application.DTOs.ISBNDB;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.IService
{
    public interface IISBNDBBookService
    {
        Task<ISBNDBBookDTO> GetBooksAsync(BookSearchCriteria searchCriteria);
    }
}
