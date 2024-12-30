using LibraryManagement.Domain.Models;
using LibraryManagementAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.IRepository
{
    public interface IOpenLibraryBookService
    {
        Task<BookDTO> GetBooksByTitleAsync(string title);
        Task<BookDTO> GetBooksByAuthorAsync(string author);
    }
}
